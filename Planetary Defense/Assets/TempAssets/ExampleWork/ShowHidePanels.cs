using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHidePanels : MonoBehaviour
{
    // Inventory
    public CanvasGroup inventoryPanel;
    public bool inventoryUp = false;

    // Pause
    public CanvasGroup pausePanel;
    public bool pauseUp = false;

    // Start is called before the first frame update
    void Start()
    {
        // Disable Inventory Panel
        inventoryPanel.alpha = 0;
        inventoryPanel.interactable = false;
        inventoryPanel.blocksRaycasts = false;

        // Disable Pause Panel
        pausePanel.alpha = 0;
        pausePanel.interactable = false;
        pausePanel.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Control Inventory panel
        if (Input.GetKeyDown(KeyCode.I) && pauseUp == false)
        {
            // not visible
            if(inventoryUp == false)
            {
                inventoryUp = true;
                inventoryPanel.alpha = 1;
                inventoryPanel.interactable = true;
                inventoryPanel.blocksRaycasts = true;
            }
            else // Already visible
            {
                inventoryUp = false;
                inventoryPanel.alpha = 0;
                inventoryPanel.interactable = false;
                inventoryPanel.blocksRaycasts = false;
            }
        }

        // Control Pause panel
        if (Input.GetButtonDown("Pause"))
        {
            // not visible
            if (pauseUp == false)
            {
                pauseUp = true;
                pausePanel.alpha = 1;
                pausePanel.interactable = true;
                pausePanel.blocksRaycasts = true;
                Time.timeScale = 0;
            }
            else // Already visible
            {
                pauseUp = false;
                pausePanel.alpha = 0;
                pausePanel.interactable = false;
                pausePanel.blocksRaycasts = false;
                Time.timeScale = 1;
            }
        }
    }
}
