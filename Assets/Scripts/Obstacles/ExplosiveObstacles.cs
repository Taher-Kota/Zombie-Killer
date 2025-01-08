using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosiveObstacles : MonoBehaviour
{
    public GameObject Explosion;
    private HealthManager life;
    public float damage = 10f;
    private void Awake()
    {
        life = GameObject.Find("Health Bar").GetComponent<HealthManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(Explosion,transform.position, Quaternion.identity);
           
            gameObject.SetActive(false);
            //Deal Damage
            life.DealDamage(damage);
        }
        if(collision.gameObject.tag == "bullet")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
          
            gameObject.SetActive(false);
        }
    }


}
