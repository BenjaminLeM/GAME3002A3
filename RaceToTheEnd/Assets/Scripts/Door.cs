using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private float DoorSpringConst = 0f;
    [SerializeField]
    private float DoorSpringDamp = 0f;
    [SerializeField]
    private float DoorAngleOpenedPos = 0f;
    [SerializeField]
    private float DoorAngleOriginalPos = 0f;

    private HingeJoint m_hingeJoint = null;
    private JointSpring m_springJoint;

    // Start is called before the first frame update
    void Start()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
        m_hingeJoint.useSpring = true;

        m_springJoint = new JointSpring();
        m_springJoint.spring = DoorSpringConst;
        m_springJoint.damper = DoorSpringDamp;
        //passes all of the values from jointspring to hingespring
        m_hingeJoint.spring = m_springJoint;
    }

    public void OpenDoorExternal()
    {
        m_springJoint.targetPosition = DoorAngleOpenedPos;
        m_hingeJoint.spring = m_springJoint;
    }

    public void CloseDoorExternal()
    {
        m_springJoint.targetPosition = DoorAngleOriginalPos;
        m_hingeJoint.spring = m_springJoint;
    }
}
