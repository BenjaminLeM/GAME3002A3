using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    Button ResumeButton;
    [SerializeField]
    Button ExitButton;
    private void Awake()
    {
        ResumeButton.onClick.AddListener(delegate { Resume(); });
        ExitButton.onClick.AddListener(delegate { ExitGame(); });
    }

    private void Resume()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<Canvas>().enabled = false;
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
