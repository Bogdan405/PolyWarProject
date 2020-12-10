using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            anim.Play("Attack");
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("Defend");
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("Death");
        }
    }

}
