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

        // Dummy event
        //events.Add(new PopupEvent_ChangeMoney("You're rich, DUMMY!", "Oh yeah!", "Oh no!", 50000));

        // Initialize money events
        events.Add(new PopupEvent("Your work is interrupted by a scientist bursting into your office! ''Great news!'' he says ''My team just discovered a meteorite made of precious metals! If we retrieve it," +
            " we could sell it and invest the funds in our planet! Shall I put together a team to collect it?'' \n \n" + "Salvage the meteorite and gain $75?",
            "The scientist's grin stretches from ear to ear. ''Fantastic! I'll get on it right away!''",
            "A look of disbelief comes over the scientist's face. ''What!? WHY!? There's literally no reason to...!'' His protest stops abruptly. ''Very well...'' He sighs.",
            75, 0));
        //events.Add(new PopupEvent("You're rich, DUMMY!", "Oh yeah!", "Oh no!", 5000, 0));

        // Initialize Life Events
        events.Add(new PopupEvent("Your radio suddenly crackles to life as it receives an incoming transmission. ''Hello! I've got an offer for whoever's in charge around here. Seems you're having trouble with" +
            "raiders in these parts. Me and my boys are the best mercenaries in the sector and for a modest fee, we could help clean up around here. Whadya say?''\n \n" + "Hire the Mercenaries? \n -$100, +4 Stability",
            "You can practically hear the smile in the mercenary's voice. ''A pleasure doing business with you. I'll send some of my boys down right away!''",
            "''Hmmph! Very well then. Guess we'll be looking elsewhere for employment.'' With that the somewhat bitter mercenary charts a course for a neighboring system and departs.",
            -100, 4));
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
