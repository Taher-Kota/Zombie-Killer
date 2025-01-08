using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    private Animator anim;
    private bool isAlive;
    public GameObject Blood;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        isAlive = true;
        speed = 5f;
        anim.Play("Zombie_Walk");
    }
    
    void FixedUpdate()
    {
        HeightCheck();
        Move();
    }

    void Die()
    {
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        Instantiate(Blood,transform.position, Quaternion.identity);
        anim.Play("Idle");
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x,.2f,transform.position.z);
        GameManager.instance.Zombies_Score();
        gameObject.SetActive(false);
    }

    void HeightCheck()
    {
        if(transform.position.y < -.3f)
        {
            gameObject.SetActive(false);
        }
    }

    void Move()
    {
        if (isAlive)
        {
            rb.velocity = new Vector3(0f, 0f, -speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Die();
        }
    }
}
