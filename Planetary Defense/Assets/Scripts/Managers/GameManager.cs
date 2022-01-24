using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Ultra-gross quest system. Cut ASAP
    //[SerializeField]
    //GameObject HUD;
    //bool QuestComplete1 = false;
    //bool QuestComplete2 = false;
    //bool QuestComplete3 = false;
    //bool QuestComplete4 = false;
    //bool QuestComplete5 = false;

    public int lifeCount;
    public int moneyCount;
    public int killCount;
    public int spawnCount;

    // True when player wins or loses
    bool gameStarted = false;
    bool end = false;

    // Canvases to be spawned
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject victoryCanvas;

    public int currentControlScheme;

    // Helps declare size of gameworld
    //int worldMinX;
    //int worldMaxX;
    //int worldMinY;
    //int worldMaxY;
    public Vector2 worldSize = new Vector2(200, 200);

    // Helps enforce singleton
    public static GameManager Instance = null;

    // Called Before Start
    private void Awake()
    {
        currentControlScheme = 1;

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

        //Set GameManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    public void InitializeGame()
    {
        lifeCount = 25;
        moneyCount = 75;
        killCount = 0;
        spawnCount = 0;
    }

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

        // Probs gonna cut this at the first opportunity
        //CheckQuests();
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

    /// <summary>
    /// Takes an int for control scheme
    /// </summary>
    /// <param name="controlScheme"></param>
    public void SetCurrentControlScheme()
    {
        if(currentControlScheme >= 3)
        {
            currentControlScheme = 1;
        }
        else
        {
            currentControlScheme++;
        }
    }

    ///// <summary>
    ///// Ewwww! Cut quest feature ASAP!
    ///// </summary>
    //void CheckQuests()
    //{

    //    if (GameObject.Find("TowerPanel").GetComponent<TowerPanelManager>().researchLevel > 0 && QuestComplete1 == false)
    //    {
    //        QuestComplete1 = true;
    //        HUD.GetComponent<QuestsHandler>().CompleteQuest1();
    //    }

    //    if (GameObject.FindGameObjectWithTag("Tower") != null && QuestComplete2 == false)
    //    {
    //        QuestComplete2 = true;
    //        HUD.GetComponent<QuestsHandler>().CompleteQuest2();
    //    }

    //    if (GameObject.Find("Missile_Tower") != null && QuestComplete3 == false)
    //    {
    //        QuestComplete3 = true;
    //        HUD.GetComponent<QuestsHandler>().CompleteQuest3();
    //    }

    //    if (moneyCount >= 300 && QuestComplete4 == false)
    //    {
    //        QuestComplete4 = true;
    //        HUD.GetComponent<QuestsHandler>().CompleteQuest4();
    //    }

    //    if (spawnCount == 75 && QuestComplete5 == false)
    //    {
    //        QuestComplete5 = true;
    //        HUD.GetComponent<QuestsHandler>().CompleteQuest5();
    //    }
    //}

}
