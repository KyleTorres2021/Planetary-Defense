using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    //TODO: Pause event timer if one is currently taking place

    // Prefabs of event UI
    [SerializeField]
    GameObject event1;
    [SerializeField]
    GameObject event2;
    [SerializeField]
    GameObject event3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EventTimer");

        Debug.Log("Event Handler Lives!");
    }

    /// <summary>
    /// A series of gross methods to spawn individual event canvases
    /// </summary>
    void First()
    {
        Instantiate(event1);
        StartCoroutine("EventTimer");
    }
    void Second()
    {
        Instantiate(event2);
        StartCoroutine("EventTimer");
    }
    void Third()
    {
        Instantiate(event3);
        StartCoroutine("EventTimer");
    }

    // Waits between 15 and 45 seconds and triggers a random event
    IEnumerator EventTimer()
    {
        // Set random wait time
        float countdown = Random.Range(20, 60);

        // Wait duration of countdown
        yield return new WaitForSeconds(countdown);

        // Pick a random number to determine event
        int eventSelection = Random.Range(0, 3);

        // Call Event method
        if(eventSelection == 0)
        {
            First();
        }
        else if(eventSelection == 1)
        {
            Second();
        }
        else
        {
            Third();
        }
    }
}
