using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allow the player to pan the camera view
public class CameraController : MonoBehaviour
{
    public float panSpeed = 10f;
    Vector2 panLimit;
    //Vector2 cameraSize; //Necessary to 

    // Camera's position
    Vector3 pos;

    // Camera's x & y dimensions
    double cameraHalfHeight;
    double cameraWidth;
    double cameraHalfWidth;

    // Virtual Joystick
    public Joystick joystick;

    int controlScheme;

    void Start()
    {
        controlScheme = GameManager.Instance.currentControlScheme;
        panLimit = GameManager.Instance.worldSize;

        //Get size of our camera to aid in PROPERLY bounding camera.
        cameraHalfHeight = this.GetComponent<Camera>().orthographicSize;
        cameraWidth = cameraHalfHeight * this.GetComponent<Camera>().aspect;
        //cameraHalfWidth = cameraWidth * .05;
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
            case 2: // Mouse Control
                if (Input.mousePosition.y >= Screen.height - 30) // Up
                {
                    pos.y += panSpeed * Time.deltaTime;
                }
                if(Input.mousePosition.y >= Screen.height - 90 && Input.mousePosition.y < Screen.width - 30)
                {
                    pos.y += panSpeed/2 * Time.deltaTime;
                }

                if (Input.mousePosition.y <= 30) // Down
                {
                    pos.y -= panSpeed * Time.deltaTime;
                }
                if(Input.mousePosition.y <= 90 && Input.mousePosition.y > 30)
                {
                    pos.y -= panSpeed/2 * Time.deltaTime;
                }

                if (Input.mousePosition.x >= Screen.width - 30) // Right
                {
                    pos.x += panSpeed * Time.deltaTime;
                }
                if(Input.mousePosition.x >= Screen.width - 90 && Input.mousePosition.x < Screen.width - 30)
                {
                    pos.x += panSpeed / 2 * Time.deltaTime;
                }

                if (Input.mousePosition.x <= 30) // Left
                {
                    pos.x -= panSpeed * Time.deltaTime;
                }
                if (Input.mousePosition.x <= 90 && Input.mousePosition.x > 30) // Left
                {
                    pos.x -= panSpeed / 2 * Time.deltaTime;
                }
                break;
                case 3: // Mobile Controls
                    pos.y += joystick.Vertical / panSpeed;
                    pos.x += joystick.Horizontal / panSpeed;
                break;
        }

        // Clamp camera within world boundaries
        pos.x = Mathf.Clamp(pos.x, -panLimit.x + (float)cameraWidth, panLimit.x - (float)cameraWidth);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y + this.GetComponent<Camera>().orthographicSize, panLimit.y - this.GetComponent<Camera>().orthographicSize);

        Debug.Log("Pan Limit " + panLimit + "Pos " + pos);

        // Set current position to new position
        transform.position = pos;
    }

    public void MoveUp()
    {
        pos.y += panSpeed * Time.deltaTime;
    }
    public void MoveRight()
    {
        pos.x -= panSpeed * Time.deltaTime;
    }
    public void MoveDown()
    {
        pos.y -= panSpeed * Time.deltaTime;
    }
    public void MoveLeft()
    {
        pos.x += panSpeed * Time.deltaTime;
    }

    //public IEnumerator Shake(float duration, float magnitude)
    //{
    //    Vector3 originalPos = pos;

    //    float elapsed = 0.0f;

    //    while (elapsed < duration)
    //    {
    //        float x = Random.Range(-1f, 1f) * magnitude;
    //        float y = Random.Range(-1f, 1f) * magnitude;

    //        transform.position = new Vector3(x, y, transform.position.z);

    //        elapsed += Time.deltaTime;

    //        yield return null;
    //    }

    //    transform.position = originalPos;
    //}
}
