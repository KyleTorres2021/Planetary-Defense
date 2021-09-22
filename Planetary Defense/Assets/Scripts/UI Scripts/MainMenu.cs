using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Serialize fields for UI prefabs
    [SerializeField]
    GameObject gradingInfo;
    [SerializeField]
    GameObject credits;

    //Serialize field for button click sfx
    [SerializeField]
    AudioClip click;

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
}
