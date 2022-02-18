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

    // Start is called before the first frame update
    void Start()
    {
        // Get text component for later use
        //message = textObject.GetComponent<Text>();

        // Set text accordingly
        //message.text = "You killed " + GameManager.Instance.killCount + " out of " + GameManager.Instance.spawnCount + " enemies!";
    }

}
