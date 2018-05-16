using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    [SerializeField] GameObject attackHitbox;
    [SerializeField] float attackCooldown;
    float timer;
    [SerializeField] bool canAttack = true;
    [SerializeField] bool weaponEquipped = false;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
	}

    private void performAttack()
    {
        GameObject.Instantiate(attackHitbox, this.transform);        
    }

    // Update is called once per frame
    void Update () {
        if (!weaponEquipped)
        {
            meleeAttack();
        }
        else
        {
            /// GUN CONTROLLER HANDLES IT
        }
        
    }

    private void checkCooldown()
    {
        if (timer > attackCooldown)
        {
            canAttack = true;
            timer = 0;
        }
    }

    private void meleeAttack()
    {
        if (canAttack == false) timer += Time.deltaTime;

        checkCooldown();

        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            Debug.Log("Clicked Fire1");
            performAttack();
            canAttack = false;
        }
    }
}
