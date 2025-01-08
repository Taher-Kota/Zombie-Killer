using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Transform target;
    float Current_Rotation_Angle , Wanted_Rotation_Angle;
    float Current_Height , Wanted_Height;
    float Rotation_Angle_Speed,height_speed;
    float Height = 4f,OffSetZ = 8f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void LateUpdate()
    {
        FollowTank();
    }

    private void FollowTank()
    {
        Wanted_Height = target.position.y+Height;
        Current_Height = transform.position.y;

        Wanted_Rotation_Angle = target.eulerAngles.y;
        Current_Rotation_Angle = transform.eulerAngles.y;

        Current_Height = Mathf.Lerp(Current_Height, Wanted_Height, height_speed * Time.deltaTime);
        Current_Rotation_Angle = Mathf.LerpAngle(Current_Rotation_Angle, Wanted_Rotation_Angle, Rotation_Angle_Speed * Time.deltaTime);

        Quaternion current_rotation = Quaternion.Euler(0f, Current_Rotation_Angle,0f);
        transform.position = target.position;
        transform.position -= current_rotation * Vector3.forward * OffSetZ;

        transform.position = new Vector3(transform.position.x, Current_Height, transform.position.z);
    }
}
