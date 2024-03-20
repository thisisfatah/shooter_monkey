using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponData", menuName ="Data/Weapon")]
public class WeaponData : ScriptableObject
{
	public Sprite sprite;
	public int ammo;
	public int maxAmmo;
	public int damage;
	public int spawnCount;
	public float shootDelay;

	public float reloadDelay;
	public bool isReload;
}
