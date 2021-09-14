using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 worldSize;

    public int lifeCount = 50;
    public int moneyCount = 100;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("You have " + lifeCount + " Lives");
        Debug.Log("You have " + moneyCount + " Space Bucks");
    }

    // Update is called once per frame
    void Update()
    {
        // Cause a game over if player runs out of lives
        if (lifeCount <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        //Pause Action and slap the player with an error message or something.
        Debug.Log("GAME OVER!");
    }

    /// <summary>
    /// Allows moneyCount to be altered by spending/making money, works with negative numbers
    /// </summary>
    /// <param name="change"></param>
    public void ChangeMoney(int change)
    {
        moneyCount += change;
        Debug.Log("You have " + moneyCount + " Space Bucks");
    }

    /// <summary>
    /// Allows adjustment to player life count, works with negative numbers
    /// </summary>
    /// <param name="change"></param>
    public void ChangeLife(int change)
    {
        lifeCount += change;
        Debug.Log("You have " + lifeCount + " life");
    }

}
