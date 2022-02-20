using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBuilder : MonoBehaviour
{
    //Enemies
    [SerializeField]
    GameObject normal;
    [SerializeField]
    GameObject assault;

    public static WaveBuilder Instance = null;

    // 
    void Awake()
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


    /// <summary>
    /// Creates the list of enemies for spawner
    /// </summary>
    /// <returns></returns>
    public List<GameObject> BuildWave(int enemyCount)
    {
        //Declare list
        List<GameObject> wave = new List<GameObject>();

        //Adds a number of random enemies to wave list equal to enemyCount
        for( int i = 0; i < enemyCount; i++)
        {
            wave.Add(SelectEnemy());
        }

        //Returns the list once we've finished building it.
        return wave;
    }

    /// <summary>
    /// Pick a random enemy based
    /// </summary>
    /// <returns></returns>
    public GameObject SelectEnemy()
    {
        //Declare 
        GameObject enemy = null;

        //TODO: Random number generator, ways to influence percentage

        //debug
        enemy = normal;

        return enemy;
    }
}
