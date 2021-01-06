using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayScript : MonoBehaviour
{
    public Animator ThisAnimator;
	
	void SetAnimator(){
		this.ThisAnimator = GetComponent<Animator>();
	}
	
    public void playAttack()
    {
        this.ThisAnimator.Play("Attack");
    }
    public void playDefense()
    {
        this.ThisAnimator.Play("Defense");
    }
    public void playIdle()
    {
        this.ThisAnimator.Play("Idle");
    }
    public void playDeath()
    {
        this.ThisAnimator.Play("Death");
    }
}
