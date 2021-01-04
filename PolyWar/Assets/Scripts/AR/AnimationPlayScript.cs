using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayScript : MonoBehaviour
{
    public Animator ThisAnimator;
	
	void SetAnimator(){
		this.ThisAnimator = GetComponent<Animator>();
	}
	
    void playAttack()
    {
        this.ThisAnimator.Play("Attack");
    }
    void playDefense()
    {
        this.ThisAnimator.Play("Defense");
    }
    void playIdle()
    {
        this.ThisAnimator.Play("Idle");
    }
    void playDeath()
    {
        this.ThisAnimator.Play("Death");
    }
}
