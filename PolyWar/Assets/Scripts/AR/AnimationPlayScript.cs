using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayScript : MonoBehaviour
{
    public Animator ThisAnimator;
	
    public void Awake()
    {
       
    }
	void SetAnimator(){
		this.ThisAnimator = GetComponent<Animator>();
	}
	
    public void playAttack()
    {
        ThisAnimator.SetTrigger("Attack");

    }
    public void playDefense()
    {
        ThisAnimator.SetTrigger("Defend");
    }
    public void playIdle()
    {
        
    }
    public void playDeath()
    {
        ThisAnimator.SetTrigger("Die");
    }

    public bool isIdle()
    {
        return this.ThisAnimator.GetBool("Idle");
    }
}
