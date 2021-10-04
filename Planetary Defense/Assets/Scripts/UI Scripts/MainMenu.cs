using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Serialize fields for UI prefabs
    [SerializeField]
    GameObject gradingInfo;
    [SerializeField]
    GameObject credits;

    [SerializeField]
    Text optionsText;

    //Serialize field for button click sfx
    [SerializeField]
    AudioClip click;

    int currentControl = 1;

    /// <summary>
    /// Loads GameScene 
    /// </summary>
    public void StartGame()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        // Load game scene
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// Spawns GradingInfoCanvas when button is clicked
    /// </summary>
    public void ViewGradingInfo()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        // Spawn canvas
        Instantiate(gradingInfo);
    }

    /// <summary>
    /// Spawns CreditsCanvas when button is clicked
    /// </summary>
    public void ViewCredits()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        // Spawn Canvas
        Instantiate(credits);
    }

    public void OptionsHandler()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        // Ensure currentControl remains bound within acceptable range
        if (currentControl >= 3 || currentControl < 1)
        {
            currentControl = 1;
        }
        else
        {
            currentControl++;
        }

        //Label button text
        if(currentControl == 1)
        {
            optionsText.text = "WASD Control";
        }
        else if (currentControl == 2)
        {
            optionsText.text = "Arrow Control";
        }
        else
        {
            optionsText.text = "Mouse Control";
        }

        GameManager.Instance.SetCurrentControlScheme(currentControl);
    }
}
