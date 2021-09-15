﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    // Get Text UI object
    [SerializeField]
    GameObject lifeCount;
    [SerializeField]
    GameObject moneyCount;

    Text lifeCountText, moneyCountText;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        // Get text component for later use
        lifeCountText = lifeCount.GetComponent<Text>();
        moneyCountText = moneyCount.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set text accordingly
        lifeCountText.text = "Life: " + gameManager.GetComponent<GameManager>().lifeCount;
        moneyCountText.text = "Money: $" + gameManager.GetComponent<GameManager>().moneyCount;

    }
}
