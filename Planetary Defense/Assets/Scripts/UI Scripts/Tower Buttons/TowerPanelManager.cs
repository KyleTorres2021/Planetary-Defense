﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanelManager : MonoBehaviour
{
    // Serialize fields for Tower Buttons
    [SerializeField]
    GameObject normalTowerButton;
    [SerializeField]
    GameObject missileTowerButton;

    // Upgrade Sound
    [SerializeField]
    AudioClip upgrade;
    [SerializeField]
    AudioClip error;
    [SerializeField]
    AudioClip ding;

    // Keeps track of how developed player research is
    public int researchLevel = 0;

    // Gross and disgusting. Should probably be an enum
    public int normal = 0;

    void Start()
    {
        // Disable tower Buttons
        normalTowerButton.SetActive(false);
        missileTowerButton.SetActive(false);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    /// <summary>
    /// Adds next tower button in the research tree when research is done
    /// </summary>
    public void AddButton()
    {
        // Ensures player has enough money to upgrade
        if (GameManager.Instance.moneyCount > 49)
        {
            //Subtract money for upgrade
            GameManager.Instance.ChangeMoney(-50);

            // Controls the upgrade tree: Activates buttons as the player researches
            switch (researchLevel)
            {
                case 0:
                    researchLevel++;
                    //Instantiate(normalTowerButton, this.transform.position, this.transform.rotation, this.transform);
                    normalTowerButton.SetActive(true);
                    SoundManager.Instance.Play(upgrade);
                    break;
                case 1:
                    researchLevel++;
                    //Instantiate(missileTowerButton, this.transform.position, this.transform.rotation, this.transform);
                    missileTowerButton.SetActive(true);
                    SoundManager.Instance.Play(upgrade);
                    break;
            }
        }
        else
        {
            SoundManager.Instance.Play(error);
        }
    }

    /// <summary>
    /// Set gameManager activeTower to normal
    /// </summary>
    public void ClickNormal()
    {
        normal = 1;
        SoundManager.Instance.Play(ding);
    }

    /// <summary>
    /// Set gameManager activeTower to normal
    /// </summary>
    public void ClickMissile()
    {
        normal = 2;
        SoundManager.Instance.Play(ding);
    }
}