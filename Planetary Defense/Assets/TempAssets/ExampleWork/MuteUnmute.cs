using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{
    public Button musicButton;
    public Button soundButton;
    Image musicImage;
    Image soundImage;
    public Sprite MusicOn;
    public Sprite MusicOff;
    public Sprite SoundOn;
    public Sprite SoundOff;
    bool musicMuted;
    bool soundMuted;

    private void Awake()
    {
        musicImage = musicButton.GetComponent<Image>();
        soundImage = soundButton.GetComponent<Image>();
    }

    public void MuteAndUnmuteMusic()
    {
        if(musicMuted == false)
        {
            // Mute
            musicImage.sprite = MusicOff;
            musicMuted = true;
        }
        else
        {
            //unmute
            musicImage.sprite = MusicOn;
            musicMuted = false;
        }
    }

    public void MuteAndUnmuteSound()
    {
        if (soundMuted == false)
        {
            // Mute
            soundImage.sprite = SoundOff;
            soundMuted = true;
        }
        else
        {
            //unmute
            soundImage.sprite = SoundOn;
            soundMuted = false;
        }
    }
}
