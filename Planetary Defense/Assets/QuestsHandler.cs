using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsHandler : MonoBehaviour
{
    // Control panel
    public CanvasGroup questLogPanel;
    bool visible;

    [SerializeField]
    AudioClip chime;

    [SerializeField]
    public GameObject quest1;
    [SerializeField]
    public GameObject quest2;
    [SerializeField]
    public GameObject quest3;
    [SerializeField]
    public GameObject quest4;
    [SerializeField]
    public GameObject quest5;

    Text questText1, questText2, questText3, questText4, questText5;

    // Start is called before the first frame update
    void Start()
    {
        // Disable Inventory Panel
        questLogPanel.alpha = 0;

        questText1 = quest1.GetComponent<Text>();
        questText2 = quest2.GetComponent<Text>();
        questText3 = quest3.GetComponent<Text>();
        questText4 = quest4.GetComponent<Text>();
        questText5 = quest5.GetComponent<Text>();
    }

    public void OnClick()
    {
        if(visible == false)
        {
            questLogPanel.alpha = 50;
            visible = true;
        }
        else
        {
            questLogPanel.alpha = 0;
            visible = false;
        }
    }

    public void CompleteQuest1()
    {
        SoundManager.Instance.Play(chime);
        questText1.text = "Quest 1: Research your first tower - Completed!";
    }

    public void CompleteQuest2()
    {
        SoundManager.Instance.Play(chime);
        questText2.text = "Quest 2: Build your first tower - Completed!";
    }

    public void CompleteQuest3()
    {
        SoundManager.Instance.Play(chime);
        questText3.text = "Quest 3: Build a Missile Tower - Completed!";
    }

    public void CompleteQuest4()
    {
        SoundManager.Instance.Play(chime);
        questText4.text = "Quest 4: Save up $300 - Completed!";
    }

    public void CompleteQuest5()
    {
        SoundManager.Instance.Play(chime);
        questText5.text = "Quest 5: Survive your first rotation - Completed!";
    }
}
