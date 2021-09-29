using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBuild : MonoBehaviour
{
    GameObject gameManager;

    // Set sound effect to play
    [SerializeField]
    AudioClip build;
    [SerializeField]
    AudioClip error;

    [SerializeField]
    GameObject normal;
    [SerializeField]
    GameObject missile;

    [SerializeField]
    GameObject towerPanel;

    private void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        //build = Resources.Load<AudioClip>("TempSound/build");
    }

    private void OnMouseDown()
    {
        if (towerPanel.GetComponent<TowerPanelManager>().normal == 1 && gameManager.GetComponent<GameManager>().moneyCount > 24)
        {
            Debug.Log("Button " + towerPanel.GetComponent<TowerPanelManager>().normal);
            SoundManager.Instance.Play(build);
            Instantiate(normal, transform.position, transform.rotation);
            gameManager.GetComponent<GameManager>().ChangeMoney(-25);
            Destroy(this.gameObject);
        }
        else if(towerPanel.GetComponent<TowerPanelManager>().normal == 2 && gameManager.GetComponent<GameManager>().moneyCount > 74)
        {
            Debug.Log("Button " + towerPanel.GetComponent<TowerPanelManager>().normal);
            SoundManager.Instance.Play(build);
            Instantiate(missile, transform.position, transform.rotation);
            gameManager.GetComponent<GameManager>().ChangeMoney(-75);
            Destroy(this.gameObject);
        }
        else
        {
            SoundManager.Instance.Play(error);
        }

    }
}
