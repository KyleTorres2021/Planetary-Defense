using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatPanel : MonoBehaviour
{

    //Serialize Fields for Panel elements
    [SerializeField]
    GameObject towerSprite;
    [SerializeField]
    GameObject lifeBar;
    [SerializeField]
    GameObject nameText;

    // Tower whose stats are to be displayed
    GameObject tower = null;

    // Helps enforce singleton
    public static TowerStatPanel Instance = null;

    // Called Before Start
    private void Awake()
    {

        // If there is not already an instance of GameManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set GameManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            healthPercent = 0;
        }

        //Display tower health as lifebar
        lifeBar.GetComponent<Image>().fillAmount = healthPercent;
    }

    public void DisplayNewTower(GameObject newTower)
    {
        tower = newTower;

        towerSprite.GetComponent<Image>().sprite = tower.GetComponent<SpriteRenderer>().sprite;

        nameText.GetComponent<Text>().text = tower.GetComponent<Tower>().name;
    }
}
