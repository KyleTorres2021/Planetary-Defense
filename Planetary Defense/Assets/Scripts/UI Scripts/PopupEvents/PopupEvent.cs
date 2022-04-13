using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEvent : MonoBehaviour
{
    string myMessage, yesOutcome, noOutcome;
    int changeInMoney, changeInLife;

    //Constructor
    public PopupEvent(string myMessage, string yesOutcome, string noOutcome, int changeInMoney, int changeInLife)
    {
        this.myMessage = myMessage;
        this.yesOutcome = yesOutcome;
        this.noOutcome = noOutcome;

        this.changeInMoney = changeInMoney;
        this.changeInLife = changeInLife;
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

    /// <summary>
    /// Retrieve "cost" of event
    /// </summary>
    /// <returns></returns>
    public int GetChangeInMoney()
    {
        return changeInMoney;
    }

    virtual public void OnYes()
    {
        //
        GameManager.Instance.ChangeMoney(changeInMoney);
        GameManager.Instance.ChangeLife(changeInLife);
    }

    virtual public void OnNo()
    {

    }
}
