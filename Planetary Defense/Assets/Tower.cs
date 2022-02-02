using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Barebones container for the absolute basics of Tower function
/// </summary>
public class Tower : MonoBehaviour
{

    // Declare Tower Stats
    public float range = 0f;
    public float buildTime = 1f;
    public int towerCost = 0;
    private bool boosted = false;


    /// <summary>
    /// Draw a circle representing range when tower is selected
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
