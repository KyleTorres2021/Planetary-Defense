using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles attacking functionality
/// </summary>
public class Shoot : MonoBehaviour
{
    // Type of projectile equipped by this entity
    [SerializeField]
    GameObject projectileType;
    public int projectileDamage;
    public int projectileSpeed;

    //Declare Sound effects
    [SerializeField]
    AudioClip shoot;
    [SerializeField]
    AudioClip impact;

    // Declare Tower Stats
    public float range = 0f;
    public float fireRate = 0f;
    public float fireCountdown = 0f;

    // Support for targeting
    public string targetTag = "Enemy";
    private Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {
        // Set UpdateTarget() to be called every half second
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    /// <summary>
    /// Acquire new targets as necessary
    /// </summary>
    void UpdateTarget()
    {
        // Maintain a list of all enemies currently present in the game
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        // Temporary variables initially set to safe values
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTarget = null;

        //Check every enemy to determine closest one
        foreach (GameObject target in targets)
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);

            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }

        // If the nearest enemy is in range, it's set as the tower's target
        if (nearestTarget != null && shortestDistance <= range)
        {
            targetPos = nearestTarget.transform;
        }
        else
        {
            targetPos = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If there is no target, end update before things get hairy
        if (targetPos == null)
        {
            return;
        }

        // Controls rate of fire
        if (fireCountdown <= 0f)
        {
            Fire();

            //Debug.Log("FireRate: " + fireRate);

            fireCountdown = 1f / fireRate;
        }

        // Subtract time from cooldown to allow repeat firing
        fireCountdown -= Time.deltaTime;

    }

    void Fire()
    {
        // Spawn projectile
        GameObject newProjectile = Instantiate(projectileType, transform.position, transform.rotation);

        // Play Sound
        SoundManager.Instance.Play(shoot);

        // Pass along projectile's target, damage, speed, and optionally sound
        if (impact != null)
        {
            newProjectile.GetComponent<Projectile>().Initialize(targetPos, projectileDamage, projectileSpeed, impact);
        }
        else
        {
            newProjectile.GetComponent<Projectile>().Initialize(targetPos, projectileDamage, projectileSpeed);
        }

    }

}
