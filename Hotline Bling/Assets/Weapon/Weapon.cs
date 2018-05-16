using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "New Weapon")]
public class Weapon : ScriptableObject {

    public int ammo = 0;
    public Sprite sprite;
}
