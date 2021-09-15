using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBuild : MonoBehaviour
{
    [SerializeField]
    GameObject tower;

    GameObject gameManager;

    private void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnMouseDown()
    {
        if (gameManager.GetComponent<GameManager>().moneyCount > 24)
        {
            Instantiate(tower, transform.position, transform.rotation);
            gameManager.GetComponent<GameManager>().ChangeMoney(-25);
            Destroy(this.gameObject);
        }
    }
}
