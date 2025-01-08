using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarANim : MonoBehaviour
{
    private Animator anim;
    private Tank player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player =GameObject.FindGameObjectWithTag("Player").GetComponent<Tank>();
    }
    void Reshoot()
    {
        anim.Play("Idle");
        player.CanShoot = true;
    }
}
