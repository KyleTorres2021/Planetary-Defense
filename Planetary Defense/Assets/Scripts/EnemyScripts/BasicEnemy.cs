using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move Pirate Ship directly toward planet
/// </summary>
public class BasicEnemy : MonoBehaviour
{
    // Declared for use throughout script
    Vector2 destination;    // Where the Pirate Ship is headed
    public float speed = 3;     // How fast the Pirate Ship should move
    public float hp = 5;

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        // Set speed -- May need to create a system for variable speed later
        //speed = 5;

        //If planet exists, set destination to its position
        if (GameObject.FindWithTag("Planet") != null)
        {
            destination = GameObject.FindGameObjectWithTag("Planet").transform.position;
            this.gameObject.transform.rotation = Quaternion.LookRotation(destination);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Set rate of movement and move
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination, step);

        // Checks to see if enemy is out of HP and destroys itself if so
        if(hp <= 0)
        {
            // Add 5 spacebucks to player money and destroy this object
            gameManager.GetComponent<GameManager>().ChangeMoney(5);
            Destroy(this.gameObject);
        }
    }

    // Called when a collision is registered
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision!");

        if (collision.gameObject.tag == "Planet")
        {
            // Subtract one life from player total and destroy this object
            gameManager.GetComponent<GameManager>().ChangeLife(-1);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Helps other objects such as bullets deal damage to this enemy
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        hp -= damage;
    }
}
