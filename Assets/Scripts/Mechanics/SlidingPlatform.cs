using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{
    BoxCollider2D bc;
    SliderJoint2D sj;
    

    private void Awake()
    {
       bc = GetComponent<BoxCollider2D>();
       sj = GetComponent<SliderJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("LeftCollider"))
        {
            AddPostiveSpeed();
        }
        else if(collision.gameObject.CompareTag("RightCollider"))
        {
            AddNegativeSpeed();
        }

    }

    private void AddPostiveSpeed()
    {
        JointMotor2D motor = sj.motor;


        motor.motorSpeed = 1;
        sj.motor = motor;
    }

    private void AddNegativeSpeed()
    {
        JointMotor2D motor = sj.motor;

        motor.motorSpeed = -1;
        sj.motor = motor;
    }
}
