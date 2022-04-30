using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Declare for use in resume
    TimescaleManager myTimescaleManager;

    /// <summary>
    /// Registers the TimeScaleManager this object will use to pause and unpause
    /// </summary>
    /// <param name="timescaleManager"></param>
    public void AssignTimescaleManager(TimescaleManager timescaleManager)
    {
        myTimescaleManager = timescaleManager;
    }

    public void resume()
    {
        //Debug.Log("Try RESUME");
        myTimescaleManager.TogglePaused();
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene("titleScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
