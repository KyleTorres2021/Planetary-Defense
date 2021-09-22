using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    // Get Text UI object
    [SerializeField]
    GameObject textObject;

    Text message;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        // Get text component for later use
        message = textObject.GetComponent<Text>();

        // Set text accordingly
        message.text = "You killed " + gameManager.GetComponent<GameManager>().killCount + " out of " + gameManager.GetComponent<GameManager>().spawnCount + " enemies!";
    }

}
