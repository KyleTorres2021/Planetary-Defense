using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupEvent_ChangeMoney : PopupEvent
{
    int changeInMoney;

    //Constructor
    public PopupEvent_ChangeMoney(string message, string yes, string no, int changeInMoney): base(message, yes, no)
    {
        this.changeInMoney = changeInMoney;
    }

    //When yes button is clicked
    public override void OnYes()
    {
        // 
        GameManager.Instance.ChangeMoney(changeInMoney);
    }

    public override void OnNo()
    {

    }
}
