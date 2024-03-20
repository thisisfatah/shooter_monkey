using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] SpriteRenderer spriteRenderer;

	public void ChangeWeapon(WeaponData newData)
    {
		spriteRenderer.sprite = newData.sprite;
	}
}