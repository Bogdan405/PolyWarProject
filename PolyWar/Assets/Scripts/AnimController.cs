using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator anim;


    public void AttackAnimation()
    {
        anim.Play("Attack");
    }

    public void DefendAnimation()
    {
        anim.Play("Defend");
    }

    public void DeathAnimation()
    {
        anim.Play("Death");
    }

    public void IdleAnimation()
    {
        anim.Play("Idle");
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            AttackAnimation();
        }
        else if (Input.GetKeyDown("2"))
        {
            DefendAnimation();
        }
        else if (Input.GetKeyDown("3"))
        {
            DeathAnimation();
        }

    }
}
