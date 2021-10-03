using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimateText : MonoBehaviour
{

    public List<CanvasGroup> textHolder = new List<CanvasGroup>();
    public List<Text> textDisplayBox = new List<Text>();
    public List<string> dialogue = new List<string>();

    public string nextScene;

    int whichText = 0; //Which text will be read
    int positionInString = 0; // Which letter is being typed

    Coroutine textPusher; //so we can stop the coroutine


    // Start is called before the first frame update
    void Start()
    {
        textPusher = StartCoroutine(WriteTheText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProceedText()
    {
        // Haven't made it to the end of the string
        if(positionInString < dialogue[whichText].Length)
        {
            //stop typing the text
            StopCoroutine(textPusher);
            // show the full string
            textDisplayBox[whichText].text = dialogue[whichText];
            positionInString = dialogue[whichText].Length;
        }
        else // Have completed string
        {
            // Hide text holder
            textHolder[whichText].alpha = 0;
            textHolder[whichText].interactable = false;
            textHolder[whichText].blocksRaycasts = false;

            // Proceed to next string
            whichText++;

            //No more text, go to next scene
            if(whichText >= textDisplayBox.Count)
            {
                SceneManager.LoadScene(nextScene);
            }
            else // If there are more text boxes, show them.
            {
                positionInString = 0;
                textHolder[whichText].alpha = 1;
                textHolder[whichText].interactable = true;
                textHolder[whichText].blocksRaycasts = true;
                textPusher = StartCoroutine(WriteTheText());
            }
        }
    }

    // Controls text animation
    IEnumerator WriteTheText()
    {
        for (int i = 0; i <= dialogue[whichText].Length; i++)
        {
            textDisplayBox[whichText].text = dialogue[whichText].Substring(0, i);
            positionInString++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
