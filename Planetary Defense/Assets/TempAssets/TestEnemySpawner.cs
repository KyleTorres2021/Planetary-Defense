using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    AudioClip spawn;

    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(5, 15);

        //Debug.Log("Spawn time" + spawnTime);

        InvokeRepeating("SpawnEnemy", 0.5f, spawnTime);
    }

    void SpawnEnemy()
    {
        // Spawn enemy
        if (GameManager.Instance.spawnCount < 75)
        {
            GameManager.Instance.spawnCount += 1;
            GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
            SoundManager.Instance.Play(spawn);
        }
    }


}
