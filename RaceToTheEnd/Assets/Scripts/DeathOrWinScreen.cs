using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathOrWinScreen : MonoBehaviour
{
    [SerializeField]
    Button RestartButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(delegate { Reset(); });

    }

    private void Reset()
    {
        SceneManager.LoadScene("RaceToTheFinish");
    }
}
