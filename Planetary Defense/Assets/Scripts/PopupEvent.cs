using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEvent : MonoBehaviour
{
    string myMessage, yesOutcome, noOutcome;

    //Constructor
    public PopupEvent(string myMessage, string yesOutcome, string noOutcome)
    {
        this.myMessage = myMessage;
        this.yesOutcome = yesOutcome;
        this.noOutcome = noOutcome;
    }

    //Retrieve string for message
    public string GetMessage()
    {
        return myMessage;
    }

    virtual public void OnYes()
    {

    }

    virtual public void OnNo()
    {

    }
}
