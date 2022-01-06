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
    public GameObject tower;

    // Which camera world to point will use
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    public void InitializeBuild(GameObject towerToBuild)
    {
        tower = towerToBuild;
    }

    public void Update()
    {
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Object position matches mouse position - Done this way or else Z-Axis is same as camera's, making object invisible to player
        this.gameObject.transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);

        // Attempts to build tower when left mouse is up
        if (Input.GetMouseButtonDown(0))
        {
            TryBuild();
        }
    }

    // Build tower if able
    void TryBuild()
    {
        if (GameManager.Instance.moneyCount >= tower.GetComponent<Tower>().towerCost)
        {
            // Subtract build cost from player money
            GameManager.Instance.moneyCount -= tower.GetComponent<Tower>().towerCost;

            // Build tower and destroy draggable
            Instantiate(tower, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            // Destroy draggable if build fails
            Destroy(this.gameObject);
        }
    }

}
