using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMarker : MonoBehaviour
{
    public LineRenderer rangeRenderer;

    public void DrawCircle(int steps, float radius)
    {
        rangeRenderer.positionCount = steps;

        float scaledRadius = radius * 2;

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
}
