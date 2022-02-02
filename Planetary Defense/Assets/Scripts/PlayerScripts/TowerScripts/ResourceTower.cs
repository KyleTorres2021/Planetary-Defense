using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Adds this ResourceTower to list at spawn
        GameManager.Instance.resources.Add(this);
    }

    // 
    private void OnDestroy()
    {
        GameManager.Instance.resources.Remove(this);
    }
}
