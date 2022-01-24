using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Used to determine acceptable spawn positions
    float minX;
    float maxX;
    float minY;
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve world size data for use in spawn boxes
        minX = -GameManager.Instance.worldSize.x;
        maxX = GameManager.Instance.worldSize.x;
        minY = -GameManager.Instance.worldSize.y;
        maxY = GameManager.Instance.worldSize.x;

        //Debug.Log("Min X: " + minX + "Max X: " + maxX + "min Y: " + minY + "max y: " + maxY);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
