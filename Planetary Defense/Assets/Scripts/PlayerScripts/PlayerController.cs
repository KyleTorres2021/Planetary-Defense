using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerIncome;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddRevenue", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddRevenue()
    {
        GameManager.Instance.ChangeMoney(GameManager.Instance.resources.Count);

    }
}
