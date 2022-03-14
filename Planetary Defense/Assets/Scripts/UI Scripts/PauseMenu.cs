using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void resume()
    {

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
