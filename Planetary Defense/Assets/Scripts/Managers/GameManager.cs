using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 worldSize;

    public int lifeCount = 30;
    public int moneyCount = 50;
    public int killCount = 0;
    public int spawnCount = 0;

    // True when player wins or loses
    bool end = false;

    // Canvases to be spawned
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject victoryCanvas;

    //public static GameManager Instance = null;

    //// Called Before Start
    //private void Awake()
    //{
    //    // If there is not already an instance of GameManager, set it to this.
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    //If an instance already exists, destroy whatever this object is to enforce the singleton.
    //    else if (Instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //
    //    //Set GameManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
    //    DontDestroyOnLoad(gameObject);
    //}

    // Update is called once per frame
    void Update()
    {
        // Cause a game over if player runs out of lives
        if (lifeCount <= 0)
        {
            GameOver();
        }

        // Endgame when
        if (spawnCount >= 75)
        {
            EndGame();
        }
    }

    void GameOver()
    {
        //Pause Action and slap the player with an error message or something.
        if (!end)
        {
            end = true;
            Instantiate(gameOver);
        }
    }

    void EndGame()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            if (!end)
            {
                end = true;
                Instantiate(victoryCanvas);
            }
        }
    }

    /// <summary>
    /// Allows moneyCount to be altered by spending/making money, works with negative numbers
    /// </summary>
    /// <param name="change"></param>
    public void ChangeMoney(int change)
    {
        // Make sure money isn't negative
        if (moneyCount + change < 0)
        {
           moneyCount = 0;
        }
        else // Add change to current money
        {
            moneyCount += change;
        }
    }

    /// <summary>
    /// Allows adjustment to player life count, works with negative numbers
    /// </summary>
    /// <param name="change"></param>
    public void ChangeLife(int change)
    {
        lifeCount += change;
    }

    /// <summary>
    /// Increases killCount by 1 when called
    /// </summary>
    public void IncreaseKills()
    {
        killCount++;
    }

}
