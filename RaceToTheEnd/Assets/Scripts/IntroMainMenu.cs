using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMainMenu : MonoBehaviour
{
    [SerializeField]
    Button StartButton;
    [SerializeField]
    Button InstructionsButton;
    [SerializeField]
    Text ControlsButtonText;
    [SerializeField]
    Text InstructionsButtonText;
    [SerializeField]
    Text ControlsText;
    [SerializeField]
    Text InstructionsText;
    [SerializeField]
    Button ExitButton;
    [SerializeField]
    Canvas IntroScreen;
    
    private void Awake()
    {
        StartButton.onClick.AddListener(delegate { StartGame(); });
        InstructionsButton.onClick.AddListener(delegate { ControlsAndIntroButton(); });
        ExitButton.onClick.AddListener(delegate {  ExitGame(); });
    }
    private void Start()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void StartGame() 
    {
        IntroScreen.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void ControlsAndIntroButton() 
    {
        if (!InstructionsButtonText.IsActive() && InstructionsText.IsActive())
        {
            ControlsButtonText.enabled = false;
            ControlsText.enabled = true;
            InstructionsButtonText.enabled = true;
            InstructionsText.enabled = false;
        }
        else 
        {
            ControlsButtonText.enabled = true;
            ControlsText.enabled = false;
            InstructionsButtonText.enabled = false;
            InstructionsText.enabled = true;
        }
    }

    private void ExitGame() 
    {
        Application.Quit();
    }
}