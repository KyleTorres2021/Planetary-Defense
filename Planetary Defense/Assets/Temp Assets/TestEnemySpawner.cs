using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(5, 15);

        Debug.Log("Spawn time" + spawnTime);

        InvokeRepeating("SpawnEnemy", 0.5f, spawnTime);
    }

    void SpawnEnemy()
    {
        // Spawn projectile
        GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);

        //Debug.Log("Spawn!");
    }


}
