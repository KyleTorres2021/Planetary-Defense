using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleManager : MonoBehaviour
{
    bool paused = false;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject fastForward;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Controls fastforward
        if (paused == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 2.5f;
                fastForward.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                fastForward.SetActive(false);
            }
        }

        //Controls pause. Needs to be moved to its own script after initial testing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                paused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }
}
