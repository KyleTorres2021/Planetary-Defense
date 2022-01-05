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

    public void Update()
    {
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Object position matches mouse position - Done this way or else Z-Axis is same as camera's, making object invisible to player
        this.gameObject.transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);

        // Attempts to build tower when left mouse is up
        if (Input.GetMouseButtonUp(0))
        {
            TryBuild();
        }
    }

    // Build tower if able
    void TryBuild()
    {
        Instantiate(tower, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
