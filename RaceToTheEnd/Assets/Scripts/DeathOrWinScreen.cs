using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathOrWinScreen : MonoBehaviour
{
    [SerializeField]
    Button RestartButton;
    [SerializeField]
    Text DeathText;
    [SerializeField]
    Text WinText;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Transform StartLoc;
    [SerializeField]
    MeshRenderer Key1;
    [SerializeField]
    MeshRenderer Key2;
    [SerializeField]
    MeshRenderer Key3;
    [SerializeField]
    InGameTimer gameTimer;

    private void Awake()
    {
        RestartButton.onClick.AddListener(delegate { Reset(); });
        
    }

    private void Reset()
    {
        Time.timeScale = 1.0f;
        Player.transform.position = StartLoc.position;
        Player.GetComponent<PlayerControls>().isDead = false;
        Key1.enabled = true;
        Key2.enabled = true;
        Key3.enabled = true;
        gameTimer.SetTimer(0.0f);
        DeathText.enabled = false;
        WinText.enabled = false;
        GetComponent<Canvas>().enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
