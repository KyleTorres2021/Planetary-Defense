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
    

    // Awake is called before Start
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

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increases wave count and begins wave when UI button is clicked.
    /// </summary>
    public void BeginNextWave()
    {
        Debug.Log(startButton);
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
        //DEbug
        Debug.Log("Spawning finished!");

        //Invoke Check for enemies to ensure things don't happen when we don't want them to.
        InvokeRepeating("CheckForEnemies", 0, 2);
    }

    /// <summary>
    /// Helper method for Endwave() Returns true if no enemies are in play
    /// </summary>
    /// <returns></returns>
    void CheckForEnemies()
    {
        Debug.Log("Checking for enemies...");
        if (GameObject.FindWithTag("Enemy") == null)
        {
            Debug.Log(startButton);

            //StartEvent()
            startButton.SetActive(true);

            CancelInvoke("CheckForEnemies");
        }

    }

}
