using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    public static BulletBehaviour instance;


    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        speed = 3000f;
        Invoke("Deactivate", 5f);
    }
    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Move()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            gameObject.SetActive(false);
        }
    }

}
