using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float playerIncome;

    bool paused = false;

    public static PlayerManager Instance = null;

    // List of ResourceTowers is used to determine player income
    public List<ResourceTower> resources = new List<ResourceTower>();

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddRevenue", 1, 2);
    }


    void AddRevenue()
    {
        if (WaveManager.Instance.waveActive == true)
        {
            GameManager.Instance.ChangeMoney(resources.Count);
        }
    }
}
