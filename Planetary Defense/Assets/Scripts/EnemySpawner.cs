using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Vital to creating spawn boxes
    Vector2 worldSize;
    float spawnDelay = 2;

    //Makes enemy spawner accessible to wave control
    public static EnemySpawner Instance = null;

    // DEBUG
    //[SerializeField]
    //GameObject enemy;

    private void Awake()
    {
        // If there is not already an instance of GameManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 
        worldSize = GameManager.Instance.worldSize;
    }

    /// <summary>
    /// Accepts a list of enemies to spawn and passes each enemy in the list to ChooseSpawn()
    /// </summary>
    /// <param name="enemies"></param>
    public IEnumerator SpawnWave(List<GameObject> enemies)
    {
        //Iterates through enemies and spawns
        for (int i = 0; i < enemies.Count; i++)
        {
            ChooseSpawn(enemies[i]);

            // Delay between spawn
            yield return new WaitForSeconds(spawnDelay);
        }

        WaveManager.Instance.EndWave();
    }

    /// <summary>
    /// Selects a random position in one of 4 spawn zones. Takes an enemy to spawn.
    /// </summary>
    /// <param name="enemy"></param>
    void ChooseSpawn(GameObject enemy)
    {
        // Used to randomly select spawn box
        int chooseSpawn = Random.Range(0, 4);

        //
        switch (chooseSpawn)
        {
            case 0: // North Spawn
                SpawnEnemy(Random.Range(-worldSize.x, worldSize.x), Random.Range(worldSize.y + 5, worldSize.y + 10), enemy);
                break;
            case 1: // East Spawn
                SpawnEnemy(Random.Range(worldSize.x + 5, worldSize.x + 10), Random.Range(worldSize.y, -worldSize.y), enemy);
                break;
            case 2: // South Spawn
                SpawnEnemy(Random.Range(-worldSize.x, worldSize.x), Random.Range(-worldSize.y - 10, -worldSize.y - 5), enemy);
                break;
            case 3: // West Spawn
                SpawnEnemy(Random.Range(-worldSize.x - 10, -worldSize.x - 5), Random.Range(worldSize.y, -worldSize.y), enemy);
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
        //Debug.Log("Spawned Enemy at " + xPos + ", " + yPos);

        Instantiate(Enemy, new Vector3(xPos, yPos), this.gameObject.transform.rotation);
    }
}
