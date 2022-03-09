using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
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
        // Controls fastforward
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 2.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void AddRevenue()
    {
        if (WaveManager.Instance.waveActive == true)
        {
            GameManager.Instance.ChangeMoney(GameManager.Instance.resources.Count);
        }
    }
}
