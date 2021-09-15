using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;

    public static SoundManager Instance = null;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip);
    }

    //// Play a looped clip through the sound effects source.
    //public void PlayLoop(AudioClip clip)
    //{
    //    DecelSource.clip = clip;
    //    DecelSource.loop = true;
    //    if (!UIManager.Instance.IsPaused)
    //    {
    //        DecelSource.Play();
    //    }
    //}

    //public void StopLoop()
    //{
    //    DecelSource.Stop();
    //    DecelSource.clip = null;
    //}

    //// Play a single clip through the music source.
    //public void PlayMusic(AudioClip clip)
    //{
    //    MusicSource.clip = clip;
    //    MusicSource.loop = true;
    //    MusicSource.volume = 0.05f;
    //    MusicSource.Play();
    //}

    //public void StopMusic()
    //{
    //    MusicSource.Stop();
    //    MusicSource.clip = null;
    //}

    // Play a random clip from an array
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);

        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }

}
