using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Contrainer", menuName ="Data/Container")]
public class WeaponContainer : ScriptableObject
{
    public List<WeaponData> weapons;
}
