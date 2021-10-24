using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterSwap : MonoBehaviour
{
    public Image characterImage;
    public Image selectedImage;
    Dropdown dropDown;

    void Awake()
    {
        dropDown = GetComponent<Dropdown>();
    }

    public void DropDownSelection(int selectionIndex)
    {
        Debug.Log("Player selected " + dropDown.options[selectionIndex].text);
        characterImage.sprite = selectedImage.sprite;
    }
}
