using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 worldSize;

    public int lifeCount = 50;
    public int moneyCount = 50;

    // GameOver canvas for, you guessed it
    [SerializeField]
    GameObject gameOver;

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
        Instantiate(gameOver);
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

}
