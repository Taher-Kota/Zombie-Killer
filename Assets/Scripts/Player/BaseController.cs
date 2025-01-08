using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 speed;
    private float X_Speed = 8f, Z_Speed = 15f;
    private float acceleration = 15f, deacceleration = 10f;
    private bool isSlow = false;
    private Animator anim;
    protected float RotationSpeed = 10f, MaxAngle = 10f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        speed = new Vector3(0f, 0f, Z_Speed);
    }

    protected void MoveLeft()
    {
        speed = new Vector3(-X_Speed/2f, 0f, speed.z);
    }

    protected void MoveRight()
    {
        speed = new Vector3(X_Speed/2f, 0f, speed.z);
    }

    protected void MoveStraight()
    {
        speed = new Vector3(0f, 0f, speed.z);
    }
    protected void MoveNormal()
    {
        if (isSlow)
        {
            isSlow = false;
        }
        speed = new Vector3(speed.x, 0f, Z_Speed);
    }

    protected void MoveSlow()
    {
        if (!isSlow)
        {
            isSlow = true;
        }
        speed = new Vector3(speed.x, 0f, deacceleration);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, acceleration);
    }
}
