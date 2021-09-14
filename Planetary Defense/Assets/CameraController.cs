using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allow the player to pan the camera view
public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public Vector2 panLimit = new Vector2(14, 14);

    GameObject gameManager;

    void Start()
    {
        // DEBUG
        if (GameObject.FindWithTag("GameController") != null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // Read player input
        if(Input.GetKey("w"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        // DEBUG
        if (Input.GetKey("q"))
        {
            gameManager.GetComponent<GameManager>().ChangeMoney(-10);
        }

        // Clamp camera within world boundaries
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        // Set current position to new position
        transform.position = pos;
    }
}
