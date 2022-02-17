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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Creates the list of enemies for spawner
    /// </summary>
    /// <returns></returns>
    public List<GameObject> BuildWave()
    {
        //Declare list
        List<GameObject> wave = new List<GameObject>();

        //for( i = 0; i < enemyCount; i++){
        //wave.add(AddEnemy())
        //}

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

        return enemy;
    }
}
