using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    [SerializeField]
    GameObject yes;

    [SerializeField]
    GameObject no;

    // Click sfx
    [SerializeField]
    AudioClip click;

    GameObject gameManager;

    private void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    public void OnClickYes()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        if (gameManager.GetComponent<GameManager>().moneyCount > 99)
        {
            Instantiate(yes, transform.position, transform.rotation);
            gameManager.GetComponent<GameManager>().ChangeMoney(50);
            Destroy(this.gameObject);
        }
    }

    public void OnClickNo()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Instantiate(no, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
