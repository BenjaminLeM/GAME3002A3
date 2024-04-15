using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Door LeftDoor;
    [SerializeField]
    private Door RightDoor;
    [SerializeField]
    private Canvas DoorWarning;
    [SerializeField]
    private MeshRenderer DoorKey;
    private bool DoorIsOpening = false;
    private bool PlayerIsInTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Player")) 
        {
            PlayerIsInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("Player"))
        {
            PlayerIsInTrigger = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIsInTrigger && !DoorKey.enabled)
        {
            DoorIsOpening = !DoorIsOpening;
        }
        else if (Input.GetKeyDown(KeyCode.E) && PlayerIsInTrigger && DoorKey.enabled) 
        {
            DoorWarning.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    private void FixedUpdate()
    {
        
        float dt = Time.deltaTime;
        if (DoorIsOpening) 
        {
            LeftDoor.OpenDoorExternal();
            RightDoor.OpenDoorExternal();
        }
        else 
        { 
            LeftDoor.CloseDoorExternal();
            RightDoor.CloseDoorExternal();
        }
    }

}
