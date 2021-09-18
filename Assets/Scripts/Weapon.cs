using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Weapon")]
public class Weapon : UnityEngine.ScriptableObject
{
    public Sprite sprite;
    public int damage;
    public float cooldown;
}
