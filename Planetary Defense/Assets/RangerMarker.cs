using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMarker : MonoBehaviour
{
    // Line renderer we will use for drawing range
    public LineRenderer rangeRenderer;

    /// <summary>
    /// Complicated circle shit I don't understand
    /// </summary>
    /// <param name="steps"></param>
    /// <param name="radius"></param>
    public void DrawCircle(int steps, float radius)
    {
        rangeRenderer.positionCount = steps;

        float scaledRadius = radius * 2f;

        for(int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float) currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * scaledRadius;
            float y = yScaled * scaledRadius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            rangeRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    public void HideCircle()
    {
        rangeRenderer.positionCount = 0;
    }
}
