using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Weapon", menuName="Weapon")]
public class WeaponObject : ScriptableObject
{
    public GameObject BulletObject;
    public string Name;
    public float CooldownTime;
}
