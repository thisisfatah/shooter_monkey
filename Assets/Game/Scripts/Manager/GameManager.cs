using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	[SerializeField] ShootSystem shootSystem;
	[SerializeField] Weapon weapon;
	[SerializeField] WeaponContainer weaponContainer;
	[SerializeField] TextMeshProUGUI ammoText;

	WeaponData weaponData;

	public static int GetAmmo
	{
		get
		{
			if(Instance.weaponData != null) return Instance.weaponData.ammo;

			return 0;
		}
		private set { }
	}

	public static int GetBulletDamage
	{
		get
		{
			if (Instance.weaponData != null) return Instance.weaponData.damage;

			return 0;
		}
		private set { }
	}

	public ShootSystem GetShootSystem { get { return shootSystem; } }
	public Weapon GetWeapon { get { return weapon; } }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{
		ChangeWeapon(1);

		weaponContainer.ResetAmmo();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			ChangeWeapon(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			ChangeWeapon(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			ChangeWeapon(3);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			ChangeWeapon(4);
		}
	}

	public static int BulletSpawnCount()
	{
		if (Instance == null) return 0;

		return Instance.weaponData.spawnCount;
	}

	public static float ShootDelay()
	{
		if (Instance == null) return 0;

		return Instance.weaponData.shootDelay;
	}

	public void ChangeWeapon(int index)
	{
		weaponData = weaponContainer.weapons[index - 1];

		GetWeapon.ChangeWeapon(weaponData);
		ammoText.text = Instance.weaponData.ammo.ToString();
	}

	public static void DecreaseAmmo()
	{
		if (Instance == null) return;
		Instance.weaponData.ammo -= 1;
		Instance.ammoText.text = Instance.weaponData.ammo.ToString();

		if(Instance.weaponData.ammo <= 0)
		{
			Instance.ReloadAmmo(Instance.weaponData);
		}
	}

	public void ReloadAmmo(WeaponData weaponToReload)
	{
		if (Instance == null) return;

		if(weaponToReload.ammo >= weaponToReload.maxAmmo) return;
		if (weaponToReload.isReload) return;

		weaponToReload.isReload = true;

		StartCoroutine(DelayReloadAmmo(weaponToReload));
	}

	IEnumerator DelayReloadAmmo(WeaponData weaponToReload)
	{
		yield return new WaitForSeconds(weaponToReload.reloadDelay);

		weaponToReload.ammo = weaponToReload.maxAmmo;
		weaponToReload.isReload = false;
	}
}
