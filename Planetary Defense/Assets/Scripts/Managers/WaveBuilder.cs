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
    [SerializeField]
    GameObject ram;

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
        //Declare enemy for assignment 
        GameObject enemy = null;

        //Random number Generator
        int randomEnemy;


        //TODO: Random number generator, ways to influence percentage
        //if(WaveManager.Instance.waveCount > 2) //Starting on Wave 3
        //{
            randomEnemy = Random.Range(0,3);

        switch(randomEnemy)
        {
            case 0:
                enemy = normal;
                break;
            case 1:
                enemy = assault;
                break;
            case 2:
                enemy = ram;
                break;
        }

        return enemy;
    }
}
