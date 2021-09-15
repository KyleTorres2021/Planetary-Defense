using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    // Serialize field will enable this script to accept multiple tower types
    [SerializeField]
    GameObject towerBuildable;

    // When button is clicked, spawn its buildable tower
   public void SpawnBuildable()
    {
        Instantiate(towerBuildable, transform.position, transform.rotation);
    }
}
