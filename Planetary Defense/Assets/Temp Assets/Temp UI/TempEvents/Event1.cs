using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    [SerializeField]
    GameObject yes;

    [SerializeField]
    GameObject no;

    GameObject gameManager;

    private void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    public void OnClickYes()
    {
        Instantiate(yes, transform.position, transform.rotation);
        gameManager.GetComponent<GameManager>().ChangeMoney(50);
        Destroy(this.gameObject);
    }

    public void OnClickNo()
    {
        Instantiate(yes, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
