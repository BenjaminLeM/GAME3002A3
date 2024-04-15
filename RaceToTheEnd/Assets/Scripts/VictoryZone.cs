using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryZone : MonoBehaviour
{
    [SerializeField]
    Canvas DeathOrWinScreen;
    [SerializeField]
    Text WinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Player") && !other.gameObject.GetComponent<PlayerControls>().isDead)
        {
            DeathOrWinScreen.enabled = true;
            WinText.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
