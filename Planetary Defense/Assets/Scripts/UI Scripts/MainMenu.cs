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

    private void Start()
    {
        //Ensure Options button reflects currently selected control choice
        UpdateOptionsText();
    }

    /// <summary>
    /// Loads GameScene 
    /// </summary>
    public void StartGame()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        //Ensure the game starts with a clean slate
        GameManager.Instance.InitializeGame();

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

        GameManager.Instance.SetCurrentControlScheme();

        UpdateOptionsText();
    }

    //
    void UpdateOptionsText()
    {
        //Label button text
        if (GameManager.Instance.currentControlScheme == 2)
        {
            optionsText.text = "Mouse Control";
        }
        else if (GameManager.Instance.currentControlScheme == 3)
        {
            optionsText.text = "Mobile Control";
        }
        else if (GameManager.Instance.currentControlScheme == 1)  //Note that WASD is set as default in case weirdness happens
        {
            optionsText.text = "WASD Control";
        }
    }
}
