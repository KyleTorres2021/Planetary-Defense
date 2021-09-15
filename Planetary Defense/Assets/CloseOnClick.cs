using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnClick : MonoBehaviour
{

    // Click sfx
    [SerializeField]
    AudioClip click;

    public void DestroyCanvas()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Destroy(this.gameObject);
    }
}
