using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEvent_ChoiceWindow : MonoBehaviour
{
    // text object to be manipulated
    [SerializeField]
    GameObject textObject;

    // secondary event window to spawn in with results
    [SerializeField]
    GameObject resolutionWindow;

    // Declare for use throughout event window
    PopupEvent myEvent;

    // Start is called before the first frame update
    void Start()
    {
        // Recieve event from popup event manager
        myEvent = PopupEvent_Manager.Instance.currentEvent;

        //get message and pass it to textbox
        textObject.GetComponent<Text>().text = myEvent.GetMessage();
    }

    //When player clicks yes
    public void OnYes()
    {
        // Ensures we have enough money to initiate the event
        if (GameManager.Instance.moneyCount + PopupEvent_Manager.Instance.currentEvent.GetChangeInMoney() >= 0)
        {
            //textObject.GetComponent<Text>().text = myEvent.GetYesMessage();
            myEvent.OnYes();

            GameObject myResolution = Instantiate(resolutionWindow);
            myResolution.GetComponent<PopupEvent_ResolutionWindow>().which = true;

            Destroy(this.gameObject);
        }
    }

    //When player clicks no
    public void OnNo()
    {
        //textObject.GetComponent<Text>().text = myEvent.GetNoMessage();
        myEvent.OnNo();

        GameObject myResolution = Instantiate(resolutionWindow);
        myResolution.GetComponent<PopupEvent_ResolutionWindow>().which = false;

        Destroy(this.gameObject);
    }
}
