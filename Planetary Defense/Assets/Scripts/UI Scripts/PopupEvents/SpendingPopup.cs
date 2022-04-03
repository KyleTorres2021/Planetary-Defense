using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpendingPopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = gameObject.GetComponent<TextMeshPro>();
    }

    /// <summary>
    /// Configure position and text for spending popup
    /// </summary>
    /// <param name="position"></param>
    /// <param name="spendingAmount"></param>
    public void Initialize(int spendingAmount)
    {
        // Increase y coordinate to display above object
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        gameObject.transform.position = newPosition;

        //Set text and set self-destruct
        textMesh.SetText("- $" + spendingAmount.ToString());
        StartCoroutine("DestroySelf");
    }

    /// <summary>
    /// Coroutine to destroy popup
    /// </summary>
    /// <returns></returns>
    IEnumerator DestroySelf()
    {
        //transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime / 10);

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}
