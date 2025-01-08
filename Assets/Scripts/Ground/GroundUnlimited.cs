using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundUnlimited : MonoBehaviour
{
    public GameObject otherGround;
    private float HalfDist = 100f;
    //private float endset = 10f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z -10f > HalfDist + transform.position.z )
        {
            transform.position = new Vector3(otherGround.transform.position.x, otherGround.transform.position.y, otherGround.transform.position.z + HalfDist * 2);
        }
    }
}
