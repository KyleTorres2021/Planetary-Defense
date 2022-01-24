using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Vital to creating spawn boxes
    Vector2 worldSize;

    // DEBUG
    [SerializeField]
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // 
        worldSize = GameManager.Instance.worldSize;

        // DEBUG
        InvokeRepeating("ChooseSpawn", 5, 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Selects a random position in one of 4 spawn zones
    /// </summary>
    void ChooseSpawn()
    {
        int chooseSpawn = Random.Range(0, 4);

        switch(chooseSpawn)
        {
            case 0: // North Spawn
                SpawnEnemy(Random.Range(-worldSize.x, worldSize.x), Random.Range(worldSize.y+10, worldSize.y+15), enemy);
                break;
            case 1: // East Spawn
                SpawnEnemy(Random.Range(worldSize.x+10, worldSize.x+15), Random.Range(worldSize.y, -worldSize.y), enemy);
                break;
            case 2: // South Spawn
                SpawnEnemy(Random.Range(-worldSize.x, worldSize.x), Random.Range(-worldSize.y-15, -worldSize.y-10), enemy);
                break;
            case 3: // West Spawn
                SpawnEnemy(Random.Range(-worldSize.x-15, -worldSize.x-10), Random.Range(worldSize.y, -worldSize.y), enemy);
                break;
        }

    }

    /// <summary>
    /// Spawns a given enemy at the given location
    /// </summary>
    /// <param name="xPos"></param>
    /// <param name="yPos"></param>
    /// <param name="Enemy"></param>
    void SpawnEnemy(float xPos, float yPos, GameObject Enemy)
    {
        Debug.Log("Spawned Enemy at " + xPos + ", " + yPos);

        Instantiate(Enemy, new Vector3(xPos, yPos), this.gameObject.transform.rotation);
    }
}
