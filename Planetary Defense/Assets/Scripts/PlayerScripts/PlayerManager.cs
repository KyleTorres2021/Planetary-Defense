using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float playerIncome;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddRevenue", 1, 3);
    }


    void AddRevenue()
    {
        if (WaveManager.Instance.waveActive == true)
        {
            GameManager.Instance.ChangeMoney(GameManager.Instance.resources.Count);
        }
    }
}
