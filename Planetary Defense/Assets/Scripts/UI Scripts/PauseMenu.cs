using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Declare for use in resume
    TimescaleManager myTimescaleManager;

    [SerializeField]
    AudioClip click;

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
        // Play Sound
        SoundManager.Instance.Play(click);

        //Debug.Log("Try RESUME");
        myTimescaleManager.TogglePaused();
    }

    public void quitToMenu()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        SceneManager.LoadScene("titleScene");
    }

    public void quitGame()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Application.Quit();
    }
}
