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
    public float hp = 6;

    //GameObject gameManager;

    // Declare Sound Effects
    [SerializeField]
    AudioClip explode;
    [SerializeField]
    AudioClip loseLife;

    // Death Particles
    [SerializeField]
    GameObject deathParticles;
    [SerializeField]
    GameObject debrisParticles;

    //Planet Damage Particles
    [SerializeField]
    GameObject smokeParticles;

    public CameraController cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        // Set speed -- May need to create a system for variable speed later
        //speed = 5;

        cameraShake = Camera.main.GetComponent<CameraController>();

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
            // Adjust player stats
            GameManager.Instance.IncreaseKills();
            GameManager.Instance.ChangeMoney(5);

            // play sfx, instantiate death effect, and destroy this object
            SoundManager.Instance.Play(explode);
            Instantiate(deathParticles, transform.position, transform.rotation);
            Instantiate(debrisParticles, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    // Called when a collision is registered
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision!");

        if (collision.gameObject.tag == "Planet")
        {
            // Play sound effect
            SoundManager.Instance.Play(loseLife);

            //StartCoroutine(cameraShake.Shake(.5f, .1f));

            // Subtract one life from player total and destroy this object
            GameManager.Instance.ChangeLife(-1);
            Instantiate(smokeParticles, transform.position, transform.rotation);
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
