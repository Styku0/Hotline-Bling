using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            rotateToMousePosition();

            shoot();
        }

    }

    private void shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right);
        Debug.DrawRay(transform.position, -transform.right, Color.red);
        if (hit.collider.gameObject.tag == "Enemy")
        {
            hit.collider.gameObject.GetComponent<enemyBehavior>().die();
        }
        Debug.DrawRay(transform.position, -transform.right, Color.red);

    }

    void rotateToMousePosition()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

    
