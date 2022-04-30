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
    private bool showRange = false;

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
        if(showRange == false)
        {
            showRange = true;
            rangeMarker.GetComponent<RangerMarker>().DrawCircle(1000, range);
        }
        else //Hide range if already shown
        {
            showRange = false;
            rangeMarker.GetComponent<RangerMarker>().HideCircle();
        }

    }


    /// <summary>
    /// Draw a circle representing range when tower is selected
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

