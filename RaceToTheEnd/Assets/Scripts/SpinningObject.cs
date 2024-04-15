using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [SerializeField]
    float SpinSpeed = 50.0f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (rb != null) 
        {
            rb.AddTorque(rb.transform.up * SpinSpeed, ForceMode.Force);
        }
    }
}
