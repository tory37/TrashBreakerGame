using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private float ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        ballSpeed = GameplayManager.getBallSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_rigidbody.velocity = transform.forward * ballSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        var other = collision.collider;
        var otherForward = other.transform.forward;
        var ballForward = transform.forward;

        var velocity = m_rigidbody.velocity;
        var otherVelocity = m_rigidbody.velocity;

        //float angle = Vector3.Angle(otherForward, ballForward);

        float adjustAngle = Vector3.Angle(Vector3.right, other.transform.right);
        //float rotatedOther = Quaternion.Eul

        if (velocity.x > 0)
        {
            //m_rigidbody.velocity = Vector3.RotateTowards(ballForward)
        }
        
    }

   
}
