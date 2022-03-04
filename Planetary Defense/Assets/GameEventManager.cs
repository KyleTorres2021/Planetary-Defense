using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    //TODO: Pause event timer if one is currently taking place

    public static GameEventManager Instance = null;

    // Prefabs of event UI
    [SerializeField]
    GameObject event1;
    [SerializeField]
    GameObject event2;
    [SerializeField]
    GameObject event3;

    int eventSelection;

    // Start is called before the first frame update
    void Start()
    {
        // If there is not already an instance of GameManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        eventSelection = Random.Range(0, 3);
    }

    // Waits between 15 and 45 seconds and triggers a random event
    public void PickEvent()
    {

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

    void First()
    {
        GameObject.Instantiate(event1);
    }

    void Second()
    {
        GameObject.Instantiate(event2);
    }

    void Third()
    {
        GameObject.Instantiate(event3);
    }
}
