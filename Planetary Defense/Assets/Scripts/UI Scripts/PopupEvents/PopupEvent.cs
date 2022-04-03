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

    /// <summary>
    /// Retrieve string for message
    /// </summary>
    /// <returns></returns>
    public string GetMessage()
    {
        return myMessage;
    }

    /// <summary>
    /// Retrieve string for "yes" message
    /// </summary>
    /// <returns></returns>
    //Retrieve string for message
    public string GetYesMessage()
    {
        return yesOutcome;
    }

    /// <summary>
    /// Retrieve string for "no" message
    /// </summary>
    /// <returns></returns>
    //Retrieve string for message
    public string GetNoMessage()
    {
        return noOutcome;
    }

    virtual public void OnYes()
    {

    }

    virtual public void OnNo()
    {

    }
}
