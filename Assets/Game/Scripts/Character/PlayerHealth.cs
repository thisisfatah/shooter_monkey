using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : CharacterHealth
{
	[SerializeField] Image healthImg;

	[Space(10)]
	bool canMultipleHelath = true;
	bool multipleHealth = false;
	float durationMonkeyChange;
	[SerializeField] Image ChangeMonkeyImg;
	[SerializeField] Sprite changeSprite;
	Sprite defaultSprite;

	private void Start()
	{
		healthImg.fillAmount = Health / MaxHealth;

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
					MultipleHealth();
					StartCoroutine(DelayChangeMonkey());
				}
			}
		}

		if (multipleHealth)
		{
			if (durationMonkeyChange >= 20)
			{
				durationMonkeyChange = 0;
				Health = MaxHealth;
				healthImg.fillAmount = Health / MaxHealth;
				transform.localScale = new Vector3(1f, 1f);
				SkillData.CanSkill = true;
			}
			else
			{
				durationMonkeyChange += Time.deltaTime;
			}
		}
	}

	public void MultipleHealth()
	{
		multipleHealth = true;
		Health = 200;
		healthImg.fillAmount = Health / 200;
		SkillData.CanSkill = false;
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

	public override void IncreaseHealth(float value)
	{
		base.IncreaseHealth(value);
		if (multipleHealth)
		{
			healthImg.fillAmount = Health / 200;
		}
		else
		{
			healthImg.fillAmount = Health / MaxHealth;
		}
	}

	public override void DecreaseHealth(float value)
	{
		base.DecreaseHealth(value);
		if (multipleHealth)
		{
			healthImg.fillAmount = Health / 200;
		}
		else
		{
			healthImg.fillAmount = Health / MaxHealth;
		}
	}
}
