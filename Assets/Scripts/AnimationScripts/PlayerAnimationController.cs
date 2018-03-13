using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    Animator animator;

	void Awake () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        animator.SetFloat("vHorizontal", Input.GetAxisRaw("Horizontal"));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("attack");
        }
	}
}
