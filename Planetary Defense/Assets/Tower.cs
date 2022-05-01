using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Barebones container for the absolute basics of Tower function
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class Tower : MonoBehaviour
{
    [SerializeField]
    GameObject buildParticles;

    // Declare Tower Stats
    public string name = "dummy";
    public float range = 0f;
    float buildTime = 1.75f;
    public int towerCost = 0;

    private bool showRange = false;

    [SerializeField]
    GameObject rangeMarker;


    private void Start()
    {
        //Initialize build effects
        this.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        Instantiate(buildParticles, this.transform);
        StartCoroutine(FadeTo(1, buildTime));

        //Disable shooting until build is finished
        if(TryGetComponent(out Shoot shoot))
        {
            shoot.enabled = false;
        }
    }

    /// <summary>
    /// Called when this tower is clicked on
    /// </summary>
    private void OnMouseDown()
    {
        // Send this tower to stat panel for display
        TowerStatPanel.Instance.DisplayNewTower(this.gameObject);

        //Display Range if possible
        if (rangeMarker != null)
        {
            if (showRange == false)
            {
                showRange = true;
                rangeMarker.GetComponent<RangerMarker>().DrawCircle(1000, range);
            }
            else //Hide range if already shown
            {
                showRange = false;
                rangeMarker.GetComponent<RangerMarker>().HideCircle();
            }
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = this.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            this.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }

        //Enable shooting now that build is finished
        if (TryGetComponent(out Shoot shoot))
        {
            shoot.enabled = true;
        }
    }


    /// <summary>
    /// Draw a circle representing range when tower is selected
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

