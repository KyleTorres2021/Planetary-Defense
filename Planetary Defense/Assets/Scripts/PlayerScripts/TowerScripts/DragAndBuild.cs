using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Alows the player to click and drag 
/// </summary>
public class DragAndBuild : MonoBehaviour
{
    //
    bool canBuild = true;

    // What tower prefab will be built
    public GameObject tower;

    // Which camera world to point will use
    private Camera cam;

    SpriteRenderer spriteRenderer;

    Color normalColor = new Color(1, 1, 1, .5f);
    Color redColor = new Color(250, 0, 0, .5f);

    // Start is called before the first frame update
    void Start()
    {
        // Set main camera for screen to world
        cam = Camera.main;

    }

    // Called by TowerPanelManager to pass in the tower to build
    public void InitializeBuild(GameObject towerToBuild)
    {
        // Set Tower
        tower = towerToBuild;

        // Set Sprite and adjust alpha
        this.gameObject.GetComponent<SpriteRenderer>().sprite = towerToBuild.GetComponent<SpriteRenderer>().sprite;
        this.gameObject.GetComponent<SpriteRenderer>().color = normalColor;

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
        if (GameManager.Instance.moneyCount >= tower.GetComponent<Tower>().towerCost && canBuild == true)
        {
            // Subtract build cost from player money
            GameManager.Instance.moneyCount -= tower.GetComponent<Tower>().towerCost;

            // Build tower and destroy draggable
            GameObject newTower = Instantiate(tower, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            // Destroy draggable if build fails
            Destroy(this.gameObject);
        }


        tower = null;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canBuild = false;

        this.gameObject.GetComponent<SpriteRenderer>().color = redColor;

        Debug.Log("DragAndBuild " + canBuild);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canBuild = true;

        this.gameObject.GetComponent<SpriteRenderer>().color = normalColor;

        Debug.Log("DragAndBuild " + canBuild);
    }

}
