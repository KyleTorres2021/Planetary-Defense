using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEvent_Manager : MonoBehaviour
{
    // Serialize fields for UI popups to be displayed to player
    [SerializeField]
    GameObject alertPopup;
    [SerializeField]
    GameObject outcomePopup;

    // Declare the list of events that can populate the game
    List<PopupEvent> events;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize collection of popup events
        events = new List<PopupEvent>();

        // Initialize money events
        events.Add(new PopupEvent_ChangeMoney("DUMMY MESSAGE!", "Oh yeah!", "Oh no!", -50));
        events.Add(new PopupEvent_ChangeMoney("You're rich, DUMMY!", "Oh yeah!", "Oh no!", 50000));

        // Initialize life events
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Be able to get message and pass it to textbox
    }

    //TODO: Handle OnYes() OnNo() in THIS script!
}
