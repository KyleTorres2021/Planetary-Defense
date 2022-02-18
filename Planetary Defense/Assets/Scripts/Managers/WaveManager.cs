using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Wave Start Button
    [SerializeField]
    GameObject startButton;

   public static WaveManager Instance = null;

    //
    int waveCount = 0; //Which number wave we're on
    bool waveActive = false; //Whether we are currently spawning enemies
    

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increases wave count and begins wave when UI button is clicked.
    /// </summary>
    public void BeginNextWave()
    {
        startButton.SetActive(false);
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
        StartCoroutine(EnemySpawner.Instance.SpawnWave(waveList));
    }

    
    public void EndWave()
    {
        //StartEvent()
        startButton.SetActive(true);
    }


}
