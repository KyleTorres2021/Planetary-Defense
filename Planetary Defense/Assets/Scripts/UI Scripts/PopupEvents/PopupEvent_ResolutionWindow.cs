using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupEvent_ResolutionWindow : MonoBehaviour
{
    // text object to be manipulated
    [SerializeField]
    GameObject textObject;

    // Which answer did the player choose?
    public bool which;

    // Start is called before the first frame update
    void Start()
    {
        if(which == true)
        {
            textObject.GetComponent<Text>().text = PopupEvent_Manager.Instance.currentEvent.GetYesMessage();
        }
        else
        {
            textObject.GetComponent<Text>().text = PopupEvent_Manager.Instance.currentEvent.GetNoMessage();
        }
    }

    public void OnClick()
    {
        Destroy(this.gameObject);
    }
}
