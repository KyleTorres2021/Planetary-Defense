﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allow the player to pan the camera view
public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    public Vector2 panLimit = new Vector2(14, 14);

    Vector3 pos;

    int controlScheme = 1;

    void Start()
    {
        controlScheme = GameManager.Instance.currentControlScheme;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        // Read player input based on controlScheme (There must be a more streamlined way...)
        switch (controlScheme)
        {
            case 1: //WASD Controls
                if (Input.GetKey("w"))
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
                break;
            case 2: // Arrow Controls
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pos.y += panSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pos.y -= panSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pos.x += panSpeed * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pos.x -= panSpeed * Time.deltaTime;
                }
                break;
            case 3: // Mouse Control
                if (Input.mousePosition.y >= Screen.height - 5) // Up
                {
                    pos.y += panSpeed * Time.deltaTime;
                }
                if (Input.mousePosition.y <= 5) // Down
                {
                    pos.y -= panSpeed * Time.deltaTime;
                }
                if (Input.mousePosition.x >= Screen.width - 5) // Right
                {
                    pos.x += panSpeed * Time.deltaTime;
                }
                if (Input.mousePosition.x <= 5) // Left
                {
                    pos.x -= panSpeed * Time.deltaTime;
                }
                break;

        }

        // Clamp camera within world boundaries
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        // Set current position to new position
        transform.position = pos;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = pos;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, transform.position.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
    }
}
