using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Contrainer", menuName = "Data/Container")]
public class WeaponContainer : ScriptableObject
{
	public List<WeaponData> weapons = new List<WeaponData>();

	public void ResetAmmo()
	{
		for (int i = 0; i < weapons.Count; i++)
		{
			if (weapons[i].isReload || weapons[i].ammo < weapons[i].maxAmmo)
			{
				weapons[i].ammo = weapons[i].maxAmmo;
				weapons[i].isReload = false;
			}
		}
	}
}
