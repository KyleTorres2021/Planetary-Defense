using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBuild : MonoBehaviour
{
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
    }

    private void OnMouseDown()
    {
        if (towerPanel.GetComponent<TowerPanelManager>().normal == 1 && GameManager.Instance.moneyCount > 24)
        {
            Debug.Log("Button " + towerPanel.GetComponent<TowerPanelManager>().normal);
            SoundManager.Instance.Play(build);
            Instantiate(normal, transform.position, transform.rotation);
            GameManager.Instance.GetComponent<GameManager>().ChangeMoney(-25);
            Destroy(this.gameObject);
        }
        else if(towerPanel.GetComponent<TowerPanelManager>().normal == 2 && GameManager.Instance.moneyCount > 74)
        {
            Debug.Log("Button " + towerPanel.GetComponent<TowerPanelManager>().normal);
            SoundManager.Instance.Play(build);
            Instantiate(missile, transform.position, transform.rotation);
            GameManager.Instance.GetComponent<GameManager>().ChangeMoney(-75);
            Destroy(this.gameObject);
        }
        else
        {
            SoundManager.Instance.Play(error);
        }

    }
}
