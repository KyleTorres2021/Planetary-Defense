using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Alows the player to click and drag 
/// </summary>
public class DragAndBuild : MonoBehaviour
{
    // What tower prefab will be built
    [SerializeField]
    GameObject tower;

    // Which camera world to point will use
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    public void OnRightClick()
    {
        Debug.Log("Click!");

        Vector2 mousePos = new Vector2();

        // Make buildable follow mouse cursor
        Vector2 buildPosition  = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        //Instantiate(tower, buildPosition);

        //// While left mouse button is held, set it's position to the mouse cursor
        //if (Input.GetMouseButton(0))
        //{
        //    this.gameObject.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        //}
        //else
        //{
        //    //Build tower at position if position is unobstructed
        //}
    }

}
