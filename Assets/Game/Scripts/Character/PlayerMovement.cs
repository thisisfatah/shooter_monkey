using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] PlayerController2D controller;
	[SerializeField] Animator anim;

	[SerializeField] float runSpeed = 40f;
	float horizontalMove = 0f;


	[HideInInspector] public bool multiplierRunSpeed = false;
	[HideInInspector] public bool jump = false;
	bool canChangeMonkeySmall = true;
	float durationMonkeyChange;

	[Space(10)]
	[SerializeField] Image ChangeMonkeyImg;
	[SerializeField] Sprite changeSprite;
	Sprite defaultSprite;

	private void Start()
	{
		defaultSprite = ChangeMonkeyImg.sprite;
	}

	private void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		anim.SetFloat("Speed", Math.Abs(horizontalMove));

		if (SkillData.CanSkill)
		{
			if (canChangeMonkeySmall)
			{
				if (Input.GetKeyDown(KeyCode.Q))
				{
					multiplierRunSpeed = true;
					StartCoroutine(DelayChangeMonkey());
					SkillData.CanSkill = false;
				}
			}
		}

		if (multiplierRunSpeed)
		{
			if (durationMonkeyChange >= 20f)
			{
				transform.localScale = new Vector3(1.0f, 1.0f);
				durationMonkeyChange = 0f;
				multiplierRunSpeed = false;
				SkillData.CanSkill = true;
			}
			else
			{
				durationMonkeyChange += Time.deltaTime;
			}
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("IsJumping", true);
		}
	}

	public void OnLanding()
	{
		anim.SetBool("IsJumping", false);
	}

	private void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, multiplierRunSpeed);
		jump = false;
	}

	IEnumerator DelayChangeMonkey()
	{
		ChangeMonkeyImg.sprite = changeSprite;
		canChangeMonkeySmall = false;
		transform.localScale = new Vector3(0.5f, 0.5f);
		yield return new WaitForSeconds(200);
		ChangeMonkeyImg.sprite = defaultSprite;
		canChangeMonkeySmall = true;
	}
}
