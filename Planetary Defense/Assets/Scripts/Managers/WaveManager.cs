using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //
    int waveCount; //Which number wave we're on
    bool waveActive; //Whether we are currently spawning enemies
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increases wave count and begins wave when UI button is clicked.
    /// </summary>
    void BeginNextWave()
    {
        waveCount++;
        waveActive = true;
        BuildWave();
    }

    // Generates and begins spawning enemy wave
    void BuildWave()
    {
        // Get list of enemies from WaveBuilder
        List<GameObject> waveList;
        waveList = WaveBuilder.Instance.BuildWave(10); // 10 is debug. Replace later with wave's enemy count

        // Send enemy list to spawner
        EnemySpawner.Instance.SpawnWave(waveList);
    }

    //void display event(){
    //}


}
