using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanelManager : MonoBehaviour
{
    // Serialize fields for Tower Buttons
    [SerializeField]
    GameObject resourceTowerButton;
    [SerializeField]
    GameObject normalTowerButton;
    [SerializeField]
    GameObject decoyTowerButton;
    [SerializeField]
    GameObject missileTowerButton;

    // Serialize fields for build-related objects
    [SerializeField]
    GameObject dragAndBuild;
    [SerializeField]
    GameObject resourceTower;
    [SerializeField]
    GameObject basicTower;
    [SerializeField]
    GameObject decoyTower;
    [SerializeField]
    GameObject missileTower;

    // Serialize fields for spending effect
    [SerializeField]
    GameObject numbersEffect;

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
        //normalTowerButton.SetActive(false);
        //missileTowerButton.SetActive(false);
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

            //Instantiate spendingEffect
            GameObject spendingEffect = Instantiate(numbersEffect, transform.position, transform.rotation);

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
    /// Handles attempt to build resource tower
    /// </summary>
    public void ClickResource()
    {
        //normal = 1;
        if(GameManager.Instance.moneyCount < resourceTower.GetComponent<Tower>().towerCost)
        {
            SoundManager.Instance.Play(error);
        }
        else
        {
            SoundManager.Instance.Play(ding);

            GameObject myBuild = Instantiate(dragAndBuild);
            myBuild.GetComponent<DragAndBuild>().InitializeBuild(resourceTower);
        }
    }

    /// <summary>
    /// Handles attempt to build normal tower
    /// </summary>
    public void ClickNormal()
    {
        //normal = 1;
        if (GameManager.Instance.moneyCount < basicTower.GetComponent<Tower>().towerCost)
        {
            SoundManager.Instance.Play(error);
        }
        else
        {
            SoundManager.Instance.Play(ding);

            GameObject myBuild = Instantiate(dragAndBuild);
            myBuild.GetComponent<DragAndBuild>().InitializeBuild(basicTower);
        }
    }

    /// <summary>
    /// Handles attempt to build normal tower
    /// </summary>
    public void ClickDecoy()
    {
        //normal = 1;
        if (GameManager.Instance.moneyCount < decoyTower.GetComponent<Tower>().towerCost)
        {
            SoundManager.Instance.Play(error);
        }
        else
        {
            //normal = 1;
            SoundManager.Instance.Play(ding);

            GameObject myBuild = Instantiate(dragAndBuild);
            myBuild.GetComponent<DragAndBuild>().InitializeBuild(decoyTower);
        }
    }

    /// <summary>
    /// Handles attempt to build missile tower
    /// </summary>
    public void ClickMissile()
    {
        //normal = 1;
        if (GameManager.Instance.moneyCount < missileTower.GetComponent<Tower>().towerCost)
        {
            SoundManager.Instance.Play(error);
        }
        else
        {
            //normal = 2;
            SoundManager.Instance.Play(ding);

            GameObject myBuild = Instantiate(dragAndBuild);
            myBuild.GetComponent<DragAndBuild>().InitializeBuild(missileTower);
        }
    }
}
