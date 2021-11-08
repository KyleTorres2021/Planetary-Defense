using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnClick : MonoBehaviour
{

    // Click sfx
    [SerializeField]
    AudioClip click;

    public Animator panelAnim;

    private void Start()
    {
        panelAnim.SetTrigger("FadeIn");
    }

    public void DestroyCanvas()
    {
        // Play Sound
        SoundManager.Instance.Play(click);
        panelAnim.SetTrigger("FadeOut");

        Destroy(this.gameObject);
    }
}
