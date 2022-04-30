using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Barebones container for the absolute basics of Tower function
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class Tower : MonoBehaviour
{

    // Declare Tower Stats
    public string name = "dummy";
    public float range = 0f;
    public float buildTime = 1f;
    public int towerCost = 0;

    private bool boosted = false;

    [SerializeField]
    GameObject rangeMarker;


    /// <summary>
    /// Called when this tower is clicked on
    /// </summary>
    private void OnMouseDown()
    {
        // Send this tower to stat panel for display
        TowerStatPanel.Instance.DisplayNewTower(this.gameObject);

        //Display Range
        rangeMarker.GetComponent<RangerMarker>().DrawCircle(1000, range);
    }


    /// <summary>
    /// Draw a circle representing range when tower is selected
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

//[RequireComponent(typeof(LineRenderer))]
//public class RangeDisplay : MonoBehaviour
//{
//    [Range(0, 50)]
//    public int segments = 50;
//    [Range(0, 5)]
//    public float xradius = 5;
//    [Range(0, 5)]
//    public float yradius = 5;
//    LineRenderer line;

//    void Start()
//    {
//        Debug.Log("I live suckahs!");

//        line = gameObject.GetComponent<LineRenderer>();

//        line.positionCount = segments + 1;
//        line.useWorldSpace = false;
//        CreatePoints();
//    }

//    void CreatePoints()
//    {
//        float x;
//        float y;
//        float z;

//        float angle = 20f;

//        for (int i = 0; i < (segments + 1); i++)
//        {
//            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
//            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

//            line.SetPosition(i, new Vector3(x, y, 0));

//            angle += (360f / segments);
//        }
//    }
//}
