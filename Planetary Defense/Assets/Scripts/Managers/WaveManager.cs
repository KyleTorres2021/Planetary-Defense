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
    public int waveCount = 0; //Which number wave we're on
    int enemyCount = 0;
    public bool waveActive = false; //Whether we are currently spawning enemies
    

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

    /// <summary>
    /// Increases wave count and begins wave when UI button is clicked.
    /// </summary>
    public void BeginNextWave()
    {
        if (waveCount < 7)
        {
            Debug.Log(startButton);
            startButton.SetActive(false);
            waveCount++;
            enemyCount += 14;
            waveActive = true;
            BuildWave();
        }
        //else
        //{
        //    GameManager.Instance.EndGame();
        //}
    }

    // Generates and begins spawning enemy wave
    void BuildWave()
    {
        // Get list of enemies from WaveBuilder
        List<GameObject> waveList;
        waveList = WaveBuilder.Instance.BuildWave(enemyCount); // 10 is debug. Replace later with wave's enemy count

        // Send enemy list to spawner
        StartCoroutine(EnemySpawner.Instance.SpawnWave(waveList));
    }
    
    public void EndWave()
    {
        //DEbug
        //Debug.Log("Spawning finished!");

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
            CancelInvoke("CheckForEnemies");

            if (waveCount < 7)
            {
                waveActive = false;

                // Award end of wave cash bonus
                GameManager.Instance.ChangeMoney(25);

                // Start the player's end of wave event
                PopupEvent_Manager.Instance.BeginEvent();

                // Reactivate start button so player can begin next wave
                startButton.SetActive(true);
            }
            else
            {
                GameManager.Instance.EndGame();
            }
        }
    }

}
