using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float health;
	[SerializeField] float maxhealth;
	[SerializeField] Image healthImg;
	[SerializeField] SpriteRenderer spriteRenderer;
	Material originalMaterial;
	[SerializeField] Material flashMaterial;
	[SerializeField] float durationFlash;

	Coroutine flashRoutine;

	[Space(10)]
	bool canMultipleHelath = true;
	bool multipleHealth = false;
	float durationMonkeyChange;
	[SerializeField] Image ChangeMonkeyImg;
	[SerializeField] Sprite changeSprite;
	Sprite defaultSprite;

	private void Start()
	{
		healthImg.fillAmount = health / maxhealth;

		originalMaterial = spriteRenderer.material;
		defaultSprite = ChangeMonkeyImg.sprite;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			IncreaseHealth(3);
		}

		if (SkillData.CanSkill)
		{
			if (canMultipleHelath)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					multipleHealth = true;
					health = 200;
					healthImg.fillAmount = health / 200;
					SkillData.CanSkill = false;
					StartCoroutine(DelayChangeMonkey());
				}
			}
		}

		if (multipleHealth)
		{
			if (durationMonkeyChange >= 20)
			{
				durationMonkeyChange = 0;
				health = maxhealth;
				healthImg.fillAmount = health / maxhealth;
				transform.localScale = new Vector3(1f, 1f);
				SkillData.CanSkill = true;
			}
			else
			{
				durationMonkeyChange += Time.deltaTime;
			}
		}
	}

	private IEnumerator DelayChangeMonkey()
	{
		ChangeMonkeyImg.sprite = changeSprite;
		canMultipleHelath = false;
		transform.localScale = new Vector3(2f, 2f);
		yield return new WaitForSeconds(200f);
		ChangeMonkeyImg.sprite = defaultSprite;
		canMultipleHelath = true;
	}

	public void IncreaseHealth(float value)
	{
		health -= value;
		healthImg.fillAmount = health / maxhealth;
		Flash();
		if (health <= 0)
		{
			Debug.Log("Game Over");
		}
	}

	public void DecreaseHealth(float value)
	{
		if (health <= maxhealth)
		{
			health += value;
			healthImg.fillAmount = health / maxhealth;
		}
	}

	public void FullHealth()
	{
		health = maxhealth;
		healthImg.fillAmount = health / maxhealth;
	}

	private void Flash()
	{
		if (flashRoutine != null)
		{
			StopCoroutine(flashRoutine);
		}

		flashRoutine = StartCoroutine(FlashDelay());
	}

	private IEnumerator FlashDelay()
	{
		spriteRenderer.material = flashMaterial;

		yield return new WaitForSeconds(durationFlash);

		spriteRenderer.material = originalMaterial;
	}
}
