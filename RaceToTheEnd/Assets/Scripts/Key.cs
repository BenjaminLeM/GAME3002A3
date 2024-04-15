using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool PlayerIsInTrigger = false;
    private MeshRenderer self;
    private void Awake()
    {
        self = GetComponent<MeshRenderer>();
    }
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
        if (Input.GetKeyDown(KeyCode.F) && PlayerIsInTrigger) 
        {
            self.enabled = false;
        }
    }
}
