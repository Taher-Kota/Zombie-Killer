using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public class Tank : BaseController
{
    private Rigidbody rb;
    public Transform BulletPosition;
    public GameObject Bullets;
    public ParticleSystem FX_Shoot;
    [HideInInspector]
    public bool CanShoot;
    private Animator FireBaranim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CanShoot = true;
        FireBaranim = GameObject.Find("Fire Bar").GetComponent<Animator>();
    }

    private void Update()
    {
        TankControlKeyboard();
        RotateTank();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }

    void TankControlKeyboard()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveFast();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveSlow();
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            MoveStraight();
        }

        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            MoveStraight();
        }

        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)))
        {
            MoveNormal();
        }

        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
        {
            MoveNormal();
        }
    }

    void RotateTank()
    {
        if (speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 180f + MaxAngle, 0f), RotationSpeed * Time.deltaTime);
        }
        if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 180f - MaxAngle, 0f), RotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 180f, 0f), RotationSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (Time.timeScale != 0 && CanShoot)
        {
            GameObject bullet = Instantiate(Bullets, BulletPosition.position, Quaternion.identity);
            bullet.GetComponent<BulletBehaviour>().Move();
            FX_Shoot.Play();
            FireBaranim.Play("FireBar");
            CanShoot = false;
        }
    }

}
