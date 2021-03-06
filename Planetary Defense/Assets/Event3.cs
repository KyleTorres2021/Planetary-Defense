using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3 : MonoBehaviour
{
    [SerializeField]
    GameObject yes;

    [SerializeField]
    GameObject no;

    // Click sfx
    [SerializeField]
    AudioClip click;

    public Animator panelAnim;

    private void Start()
    {
        panelAnim.SetTrigger("FadeIn");
    }

    public void OnClickYes()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Instantiate(yes, transform.position, transform.rotation);
        GameManager.Instance.ChangeMoney(-50);
        GameManager.Instance.GetComponent<GameManager>().ChangeLife(-5);
        Destroy(this.gameObject);
    }

    public void OnClickNo()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Instantiate(no, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}