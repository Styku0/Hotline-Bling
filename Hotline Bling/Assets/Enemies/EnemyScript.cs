using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "New Enemy")]
public class EnemyScript : ScriptableObject {

    public Color spriteColor;
    public float size = 1;
    public float movementSpeed = 3;

}
