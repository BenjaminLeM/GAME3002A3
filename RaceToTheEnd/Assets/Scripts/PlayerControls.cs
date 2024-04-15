using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_rb;
    HingeJoint m_HingeJoint;
    JointSpring m_springJoint;
    float CameraSpring = 5000.0f;
    float CameraSpringDampen = 10.0f;
    float currentAnglePos = 0;
    Vector3 forceMovement;
    [SerializeField]
    float PlayerSpeed = 50.0f;
    [SerializeField]
    float LookSpeed = 5000.0f;
    [SerializeField]
    float jumpImpluseForce = 5000.0f;
    [SerializeField]
    Transform m_CameraTransform;
    [SerializeField]
    private Transform StartPos;
    [SerializeField]
    private Transform Key1Pos;
    [SerializeField]
    private Transform Door1Pos;
    [SerializeField]
    private Transform Key2Pos;
    [SerializeField]
    private Transform Door2Pos;
    [SerializeField]
    private Transform Key3Pos;
    [SerializeField]
    private Transform Door3Pos;
    [SerializeField]
    private Transform EndPos;
    [SerializeField]
    private Canvas DeathOrWinScreen;
    [SerializeField]
    private Text DeathText;
    [SerializeField]
    private Canvas PauseScreen;
    [SerializeField]
    private Button RestartButton;
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
        m_HingeJoint = GetComponent<HingeJoint>();
        m_HingeJoint.useSpring = true;
        m_springJoint = new JointSpring();
        m_springJoint.spring = CameraSpring;
        m_springJoint.damper = CameraSpringDampen;
        m_HingeJoint.spring = m_springJoint;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        float dt = Time.deltaTime;
        rotationAmount += mouseDelta * dt * LookSpeed;
        if (!isDead && Time.timeScale != 0)
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

            //f1-8 key warps
            if (Input.GetKeyDown(KeyCode.F1)) 
            {
                m_rb.position = StartPos.position;
            }
            if (Input.GetKeyDown(KeyCode.F2)) 
            {
                m_rb.position = Key1Pos.position;
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                m_rb.position = Door1Pos.position;
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                m_rb.position = Key2Pos.position;
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                m_rb.position = Door2Pos.position;
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                m_rb.position = Key3Pos.position;
            }
            if (Input.GetKeyDown(KeyCode.F7))
            {
                m_rb.position = Door3Pos.position;
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                m_rb.position = EndPos.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale != 0)
        {
            Time.timeScale = 0;
            PauseScreen.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    private void FixedUpdate()
    {
        if (m_rb != null) 
        {
            m_rb.AddForce(forceMovement);
            m_rb.GetComponent<Transform>().Rotate(0.0f, (rotationAmount.x / 3), 0.0f);
            m_springJoint.targetPosition = currentAnglePos + rotationAmount.y;
            m_HingeJoint.spring = m_springJoint;
            currentAnglePos += rotationAmount.y;
            if (currentAnglePos > m_HingeJoint.limits.max)
            {
                currentAnglePos = m_HingeJoint.limits.max;
            }
            else if (currentAnglePos < m_HingeJoint.limits.min) 
            {
                currentAnglePos = m_HingeJoint.limits.min;
            }
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
            if (isDead)
            {
                DeathOrWinScreen.enabled = true;
                DeathText.enabled = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                RestartButton.enabled = true;
            }
        }
    }
}
