using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EventHappens()
    {
        gameManager.GetComponent<GameManager>().ChangeMoney(25);
        Destroy(this.gameObject);
    }
}
