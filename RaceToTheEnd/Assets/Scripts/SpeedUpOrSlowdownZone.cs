using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpOrSlowdownZone : MonoBehaviour
{
    [SerializeField]
    private float SpeedEffect = 0.5f;

    //While the Player is inside the trigger box it is speed/slowed to the set value.
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity *= SpeedEffect;
            other.gameObject.GetComponent<PlayerControls>().speedUpOrSlowDownEffect = SpeedEffect;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.StartsWith("Player"))
        {
            other.gameObject.GetComponent<PlayerControls>().speedUpOrSlowDownEffect = 1.0f;
        }
    }
}
