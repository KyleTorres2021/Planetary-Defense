using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{

    // Click sfx
    [SerializeField]
    AudioClip click;

    public Animator panelAnim;

    // Start is called before the first frame update
    void Start()
    {
        panelAnim.SetTrigger("FadeIn");

        // Set GameManager for use
        GameManager.Instance.ChangeMoney(25);
    }

    public void EventHappens()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Destroy(this.gameObject);
    }
}
