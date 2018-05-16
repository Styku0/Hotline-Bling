using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {

    public EnemyScript enemyScript;
    [SerializeField] Transform player;
    [SerializeField] float movementSpeed = 2;

    [Header("Random Movement")]
    [SerializeField] float randomMovementSpeed = 0.5f;
    float timeSinceChange = 2;
    [SerializeField] float timeBetweenChanges = 5f;
    [SerializeField] Vector3 newDirection;


    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").transform;
        GameObject.FindWithTag("Respawn").GetComponent<SpawnManager>().enemiesAlive += 1;
        applyEnemyScript();

    }
	
	// Update is called once per frame
	void Update () {

        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            transform.right = player.position - transform.position;
        }
        else
        {
            
            randomMovement();
        }
        
    }

    private void randomMovement()
    {
        timeSinceChange += Time.deltaTime;
        if (timeSinceChange > (UnityEngine.Random.Range(timeBetweenChanges-1, timeBetweenChanges+1)))
        {
            timeSinceChange = 0;
            newDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);

        }
        
        transform.position += newDirection * Time.deltaTime * randomMovementSpeed;
    }

    public void die()
    {
        GameObject.FindWithTag("Respawn").GetComponent<SpawnManager>().enemiesAlive -= 1;
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Hitbox")
        {
            GameObject.FindWithTag("Respawn").GetComponent<SpawnManager>().enemiesAlive -= 1;
            GameObject.Destroy(this.gameObject);
        }
    }
    void applyEnemyScript()
    {
        if (enemyScript != null)
        {
            gameObject.GetComponent<SpriteRenderer>().color = enemyScript.spriteColor;
            movementSpeed = enemyScript.movementSpeed;
            transform.localScale = transform.localScale * enemyScript.size;
        }
    }
}
