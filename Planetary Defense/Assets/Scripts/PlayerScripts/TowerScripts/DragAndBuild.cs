using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Alows the player to click and drag 
/// </summary>
public class DragAndBuild : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // While left mouse button is held, set it's position to the mouse cursor
        if (Input.GetMouseButton(0))
        {
            //this.gameObject.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        }
        else
        {
            //Build tower at position if position is unobstructed
        }
    }
}
