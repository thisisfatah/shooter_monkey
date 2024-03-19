using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerController2D controller;
	[SerializeField] Animator anim;

	[SerializeField] float runSpeed = 40f;
	float horizontalMove = 0f;

	bool jump = false;
	bool crouch = false;

	private void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		anim.SetFloat("Speed", Math.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("IsJumping", true);
		}

		if(Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}

	public void OnLanding()
	{
		anim.SetBool("IsJumping", false);
		Debug.Log("on Land");
	}

	private void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}