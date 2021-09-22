using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // Click sfx
    [SerializeField]
    AudioClip click;

    public void GoToMenu()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        // Load game scene
        SceneManager.LoadScene("TitleScene");
    }
}
