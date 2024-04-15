using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorWarningUI : MonoBehaviour
{
    [SerializeField]
    Button ExitButton;
    Canvas canvas;
    private void Awake()
    {
        ExitButton.onClick.AddListener(delegate { CloseWindow(); });
        canvas = GetComponent<Canvas>();
    }
    private void CloseWindow()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
