using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Player")) 
        {
            collision.gameObject.GetComponent<PlayerControls>().isDead = true;
        }
    }
}
