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
        selectionAreaTransform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // While LeftMouse is held down, start drag/select
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = UtilsClass.GetMouseWorldPosition();
            selectionAreaTransform.gameObject.SetActive(true);
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = UtilsClass.GetMouseWorldPosition();

            Vector3 lowerLeft = new Vector3(Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y));

            Vector3 upperRight = new Vector3(Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y));

            // Scale selection area
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        // Left Mouse button released
        if (Input.GetMouseButtonUp(0))
        {
            // Hide selection
            selectionAreaTransform.gameObject.SetActive(false);

            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition());

            // Deactivate select effect for previously selected fighters
            foreach (Fighter fighter in selectedFighterList)
            {
                fighter.SetSelectedVisible(false);
            }

            // Make sure list is empty before adding selected fighters to it
            selectedFighterList.Clear();

            // Check all selected colliders
            foreach (Collider2D collider2D in collider2DArray)
            {
                //Debug.Log("I work!");
                // Attempt to get fighter
                Fighter fighter = collider2D.GetComponent<Fighter>();

                // If fighter exists, add it to list.
                if (fighter != null)
                {
                    selectedFighterList.Add(fighter);
                }
            }
        }
    }
}
