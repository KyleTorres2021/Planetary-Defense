using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    GameObject gameManager;

    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        spawnTime = Random.Range(5, 15);

        //Debug.Log("Spawn time" + spawnTime);

        InvokeRepeating("SpawnEnemy", 0.5f, spawnTime);
    }

    void SpawnEnemy()
    {
        // Spawn enemy
        if (gameManager.GetComponent<GameManager>().spawnCount < 75)
        {
            gameManager.GetComponent<GameManager>().spawnCount += 1;
            GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
        }
    }


}
