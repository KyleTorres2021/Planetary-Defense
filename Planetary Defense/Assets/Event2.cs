﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    GameObject gameManager;

    // Click sfx
    [SerializeField]
    AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManager.GetComponent<GameManager>().ChangeMoney(25);
    }

    public void EventHappens()
    {
        // Play Sound
        SoundManager.Instance.Play(click);

        Destroy(this.gameObject);
    }
}
