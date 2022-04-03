using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEvent_Manager : MonoBehaviour
{
    // Event window to spawn in
    [SerializeField]
    GameObject eventWindow;

    // Declare the list of events that can populate the game
    List<PopupEvent> events;

    // Declared to help track and use the current, active event
    public PopupEvent currentEvent;

    // Declare Singleton
    public static PopupEvent_Manager Instance = null;

    // Called Before Start
    private void Awake()
    {
        // If there is not already an instance of PopupManager, set it to this.
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

    // Start is called before the first frame update
    void Start()
    {
        // Initialize collection of popup events
        events = new List<PopupEvent>();

        // Initialize money events
        events.Add(new PopupEvent_ChangeMoney("DUMMY MESSAGE!", "Oh yeah!", "Oh no!", -50));
        events.Add(new PopupEvent_ChangeMoney("You're rich, DUMMY!", "Oh yeah!", "Oh no!", 50000));
    }

    /// <summary>
    /// Called to initiate an in-game event
    /// </summary>
    public void BeginEvent()
    {
        //Picks an event and spawns event canvas
        Debug.Log("Event Started");
        SelectCurrentEvent();
        Instantiate(eventWindow);
    }

    void SelectCurrentEvent()
    {
        // Get size of list to aid in selecting a random event
        int listLength = events.Count;

        // Used to select random event
        int random = Random.Range(0, listLength);

        // Set current event to a random event
        currentEvent = events[random];
    }

    
}
