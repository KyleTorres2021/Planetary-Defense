using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FighterController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTransform;

    private Vector2 startPosition;
    private List<Fighter> selectedFighterList;

    private void Awake()
    {
        selectedFighterList = new List<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        // While LeftMouse is held down, start drag/select
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = UtilsClass.GetMouseWorldPosition();
        }

        // Select relevent units if they've been dragged over
        if(Input.GetMouseButtonUp(0))
        {
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition());

            // Deactivate select effect for previously selected fighters
            foreach(Fighter fighter in selectedFighterList)
            {
                fighter.SetSelectedVisible(false);
            }

            // Make sure list is empty before adding selected fighters to it
            selectedFighterList.Clear();

            // Check all selected colliders
            foreach(Collider2D collider2D in collider2DArray)
            {
                // Attempt to get fighter
                Fighter fighter = collider2D.GetComponent<Fighter>();

                // If fighter exists, add it to list.
                if(fighter != null)
                {
                    selectedFighterList.Add(fighter);
                }
            }
        }
    }
}
