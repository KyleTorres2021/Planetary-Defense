using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    // Get Text UI object
    [SerializeField]
    GameObject lifeCount;
    [SerializeField]
    GameObject moneyCount;
    [SerializeField]
    GameObject waveNumber;

    Text lifeCountText, moneyCountText, waveNumberText;
    int life, money, kills;

    // Start is called before the first frame update
    void Start()
    {
        // Get text component for later use
        lifeCountText = lifeCount.GetComponent<Text>();
        moneyCountText = moneyCount.GetComponent<Text>();
        waveNumberText = waveNumber.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set text accordingly
        UpdateLife();
        moneyCountText.text = "Money: $" + GameManager.Instance.moneyCount;
        waveNumberText.text = "Wave: " + WaveManager.Instance.waveCount;
    }

    void UpdateLife()
    {
        if(life != GameManager.Instance.lifeCount)
        {
            life = GameManager.Instance.lifeCount;
            lifeCountText.text = "Stability: " + life;
        }
    }


    void PulseText(GameObject textObject)
    {
        // Save original size
        Vector3 originalScale = textObject.transform.localScale;

        // "pulse" object by increasing then decreasing scale.
        textObject.transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2, Time.deltaTime / 10);
        textObject.transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime / 10);
    }
}
