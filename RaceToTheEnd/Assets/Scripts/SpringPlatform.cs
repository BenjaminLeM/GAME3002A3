using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    [SerializeField]
    private SpringJoint LauncherSpring;
    [SerializeField]
    private float MaxSpringLength = 10.0f;
    [SerializeField]
    private float MinSpringLength = 1.5f;
    [SerializeField]
    private float SpringSpeed;
    
    Rigidbody m_rb;

    bool hasLaunched = false;
    float WaitTilRecharge = 0.0f;
    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        LauncherSpring.connectedAnchor = new Vector3(LauncherSpring.connectedAnchor.x,
                MinSpringLength,
                LauncherSpring.connectedAnchor.z);
        LauncherSpring.spring = SpringSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (m_rb != null) 
        {
            if (collision.gameObject.name.StartsWith("Player")) 
            {
                LauncherSpring.connectedAnchor = new Vector3(LauncherSpring.connectedAnchor.x,
                MaxSpringLength,
                LauncherSpring.connectedAnchor.z);
                hasLaunched = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float dt = Time.deltaTime;
        if (m_rb != null) 
        {
            if (hasLaunched)
            {
                m_rb.WakeUp();
                WaitTilRecharge += dt;
            }
            if (WaitTilRecharge >= 1.0f) 
            {
                hasLaunched = false;
                LauncherSpring.connectedAnchor = new Vector3(LauncherSpring.connectedAnchor.x,
                LauncherSpring.connectedAnchor.y - ((MinSpringLength * 2) * dt),
                LauncherSpring.connectedAnchor.z);
                if (LauncherSpring.connectedAnchor.y <= MinSpringLength) 
                {
                    WaitTilRecharge = 0.0f;
                }
            }
        }
    }
}
