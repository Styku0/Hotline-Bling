using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {


    public Rigidbody2D rigidbody;
    [SerializeField] float movementSpeed = 1f;

    public enum movementMode { Mode1, Mode2 };
    public movementMode mode = movementMode.Mode1;

    [SerializeField] float modeTwoModifier = 4;

    // Use this for initialization
    void Start () {
        
	}

    void FixedUpdate()
    {
        rotateToMousePosition();
        movePlayer();
    }

    private void movePlayer()
    {

        if (mode == movementMode.Mode1)
        {
            movementModeOne();
        }
        else
        {
            movementModeTwo();
        }

        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("You Died");
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pickup")
        {
            //Debug.Log("Collided with pickup");
        }
    }

    void movementModeOne()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime * movementSpeed;
        }
    }
    void movementModeTwo()
    {
        rigidbody.AddForce(-transform.right * movementSpeed/modeTwoModifier * Input.GetAxis("Vertical"), ForceMode2D.Impulse);
        rigidbody.AddForce(transform.up * movementSpeed/modeTwoModifier * Input.GetAxis("Horizontal"), ForceMode2D.Impulse);
    }


}
