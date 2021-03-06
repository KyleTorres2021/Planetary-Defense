using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatPanel : MonoBehaviour
{
    [SerializeField]
    GameObject selectedIndicator;

    //Serialize Fields for Panel elements
    [SerializeField]
    GameObject towerSprite;
    [SerializeField]
    GameObject lifeBar;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text lifeText;

    // Controls whether panel is fully visible to player
    bool hidden;

    Vector2 originalPos;
    Vector2 hiddenPos;

    // Tower whose stats are to be displayed
    GameObject tower = null;

    // Helps enforce singleton
    public static TowerStatPanel Instance = null;

    // Called Before Start
    private void Awake()
    {
        // If there is not already an instance of TowerStatPanel, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set revealed and hidden positions fo use in gameplay
        originalPos = this.transform.position;
        hiddenPos = new Vector2(this.transform.position.x, this.transform.position.y - 195);

        // Deactivate placehold sprite so its not ugly
        towerSprite.SetActive(false);
    }

    private void Start()
    {
        //Hide panel at start of game
        hidden = true;
        this.gameObject.transform.position = hiddenPos;
    }

    // Update is called once per frame
    void Update()
    {
        float healthPercent;

        // if tower exists, display its health otherwise, display an empty bar
        if(tower != null)
        {
            //Calculate tower's current health percentage
            healthPercent = tower.GetComponent<HealthBar>().hp / tower.GetComponent<HealthBar>().maxHP;
            lifeText.text = tower.GetComponent<HealthBar>().hp + "/" + tower.GetComponent<HealthBar>().maxHP;
        }
        else
        {
            healthPercent = 0;
            lifeText.text = "";
        }

        //Display tower health as lifebar
        lifeBar.GetComponent<Image>().fillAmount = healthPercent;
    }

    /// <summary>
    /// Toggles visibility of status panel when button is clicked
    /// </summary>
    public void HideShowPanel()
    {
        if(hidden)
        {
            hidden = false;
            this.gameObject.transform.position = originalPos;
        }
        else
        {
            hidden = true;
            this.gameObject.transform.position = hiddenPos;
        }
    }

    public void DisplayNewTower(GameObject newTower)
    {
        if (!towerSprite.activeSelf)
        {
            towerSprite.SetActive(true);
        }

        tower = newTower;

        hidden = false;
        this.gameObject.transform.position = originalPos;

        towerSprite.GetComponent<Image>().sprite = tower.GetComponent<SpriteRenderer>().sprite;

        nameText.text = tower.GetComponent<Tower>().name;

        //Display indicator of current tower
        if(GameObject.FindGameObjectWithTag("SelectedIndicator") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("SelectedIndicator"));
        }

        Instantiate(selectedIndicator, tower.transform);

    }
}
