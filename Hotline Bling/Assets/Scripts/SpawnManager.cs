using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public List<Wave> waves;
    public List<Vector3> spawnPoints;
    public GameObject enemy;
    public int enemiesAlive = 0;

    [SerializeField] float midWaveBreak = 5f;
    [SerializeField] int currentWave = 0;

    bool isSpawning = false;
    bool breakStarted = false;

    int enemiesSpawned = 0;
    float timer = 0f;



	// Use this for initialization
	void Start () {
        generateSpawnPoints();        
	}

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (!isSpawning)
        {
            if(enemiesAlive == 0)
            {
                if (!breakStarted)
                {
                    breakStarted = true;
                    timer = 0;
                    
                }
                else
                {
                    if (timer > midWaveBreak) startTheWave();
                }
            }
        }

         if (isSpawning)
        {
            startSpawning();
        }

	}

    void startSpawning()
    {
        if (enemiesSpawned == 0)
        {
            spawnAnEnemy();
            timer = 0;
        }
        else if ((timer > waves[currentWave].spawnRate) && (enemiesSpawned < waves[currentWave].enemies))
        {
            spawnAnEnemy();
            timer = 0;
        }
        else if (enemiesSpawned >= waves[currentWave].enemies)
        {
            isSpawning = false;
            breakStarted = false;
            currentWave += 1;
            if (currentWave >= waves.Count) currentWave = waves.Count - 1;
        }
    }

    

    private void generateSpawnPoints()
    {
        /// TOP
        spawnPoints.Add(new Vector3(10, 6, 0));
        spawnPoints.Add(new Vector3(5, 6, 0));
        spawnPoints.Add(new Vector3(0, 6, 0));
        spawnPoints.Add(new Vector3(-5, 6, 0));
        spawnPoints.Add(new Vector3(-10, 6, 0));
        /// BOTTOM
        spawnPoints.Add(new Vector3(-10, -6, 0));
        spawnPoints.Add(new Vector3(-5, -6, 0));
        spawnPoints.Add(new Vector3(0, -6, 0));
        spawnPoints.Add(new Vector3(5, -6, 0));
        spawnPoints.Add(new Vector3(10, -6, 0));
        /// LEFT
        spawnPoints.Add(new Vector3(-10, 3, 0));
        spawnPoints.Add(new Vector3(-10, 0, 0));
        spawnPoints.Add(new Vector3(-10, -3, 0));
        // RIGHT
        spawnPoints.Add(new Vector3(10, 3, 0));
        spawnPoints.Add(new Vector3(10, 0, 0));
        spawnPoints.Add(new Vector3(10, -3, 0));
    }

    void startTheWave()
    {
        isSpawning = true;
        timer = 0f;
        enemiesSpawned = 0;

    }

    void spawnAnEnemy()
    {
        enemy.GetComponent<enemyBehavior>().enemyScript = waves[currentWave].EnemyTypes[UnityEngine.Random.Range(0, waves[currentWave].EnemyTypes.Count)];

        Instantiate(enemy, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count - 1)], new Quaternion(0,0,0,0));
        
        enemiesSpawned += 1;
    }

}
