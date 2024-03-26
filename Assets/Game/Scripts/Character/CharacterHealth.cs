using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
	[SerializeField] float health;
	[SerializeField] float maxhealth;
	[SerializeField] SpriteRenderer spriteRenderer;
	Material originalMaterial;
	[SerializeField] Material flashMaterial;
	[SerializeField] float durationFlash;

	Coroutine flashRoutine;

	public float Health { get { return health; } set { health = value; } }
	public float MaxHealth { get { return maxhealth; } private set { maxhealth = value; } }

	public UnityEvent OnLandEvent;

	public virtual void IncreaseHealth(float value)
	{
		if(health <= 0) return;

		Flash();
		health -= value;

		if (health <= 0)
		{
			if (OnLandEvent != null)
				OnLandEvent.Invoke();
		}
	}

	public virtual void DecreaseHealth(float value)
	{
		if (health <= maxhealth)
		{
			health += value;
		}
	}

	public virtual void FullHealth()
	{
		health = maxhealth;
	}

	private void Flash()
	{
		if (flashRoutine != null)
		{
			StopCoroutine(flashRoutine);
		}
		else
		{
			originalMaterial = spriteRenderer.material;
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
