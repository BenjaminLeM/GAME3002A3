using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_rb;
    Vector3 forceMovement;
    [SerializeField]
    float PlayerSpeed = 50.0f;
    [SerializeField]
    float LookSpeed = 5000.0f;
    [SerializeField]
    float jumpImpluseForce = 5000.0f;
    [SerializeField]
    Transform m_CameraTransform;
    Vector2 mouseDelta = Vector2.zero;
    Vector2 rotationAmount;
    float currentPlayerSpeed;
    public bool isGrounded = true;
    public bool isDead = false;
    public float speedUpOrSlowDownEffect = 1.0f;


    private void Awake()
    {
    }
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        float dt = Time.deltaTime;
        rotationAmount += mouseDelta * dt * LookSpeed;
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.W))
            {
                forceMovement += m_rb.GetComponent<Transform>().forward * dt * currentPlayerSpeed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                forceMovement -= m_rb.GetComponent<Transform>().forward * dt * currentPlayerSpeed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                forceMovement -= m_rb.GetComponent<Transform>().right * dt * currentPlayerSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                forceMovement += m_rb.GetComponent<Transform>().right * dt * currentPlayerSpeed;
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                m_rb.AddForceAtPosition((m_rb.GetComponent<Transform>().up * dt) * jumpImpluseForce, m_rb.position, ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                currentPlayerSpeed = (PlayerSpeed * 1.3f) * speedUpOrSlowDownEffect;
            }
            else
            {
                currentPlayerSpeed = PlayerSpeed * speedUpOrSlowDownEffect;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    private void FixedUpdate()
    {
        if (m_rb != null) 
        {
            m_rb.AddForce(forceMovement);
            m_rb.GetComponent<Transform>().Rotate(0.0f, (rotationAmount.x / 3), 0.0f);
            m_CameraTransform.Rotate((rotationAmount.y / 3), 0.0f, 0.0f);
            rotationAmount = Vector2.zero;
            forceMovement = Vector3.zero;
            if (m_rb.velocity.y == 0)
            {
                isGrounded = true;
            }
            else 
            {
                isGrounded = false;
            }
        }
    }
}
