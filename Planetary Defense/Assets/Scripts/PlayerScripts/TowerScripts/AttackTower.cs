using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles attacking functionality for towers
/// </summary>
public class AttackTower : MonoBehaviour
{
    // Type of projectile equipped by this tower
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
    public float fireRate = 2f;
    public float fireCountdown = 0f;
    private bool boosted = false;

    // Support for enemy targeting
    public string enemyTag = "Enemy";
    private Transform target;

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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        // Temporary variables initially set to safe values
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Check every enemy to determine closest one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // If the nearest enemy is in range, it's set as the tower's target
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If there is no target, end update before things get hairy
        if (target == null)
        {
            return;
        }

        // Controls rate of fire
        if (fireCountdown <= 0f)
        {
            Shoot();

            //Debug.Log("FireRate: " + fireRate);

            fireCountdown = 1f / fireRate;
        }

        // Subtract time from cooldown to allow repeat firing
        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        // Spawn projectile
        GameObject newProjectile = Instantiate(projectileType, transform.position, transform.rotation);

        // Play Sound
        SoundManager.Instance.Play(shoot);

        // Pass along projectile's target, damage, speed, and optionally sound
        if (impact != null)
        {
            newProjectile.GetComponent<Projectile>().Initialize(target, projectileDamage, projectileSpeed, impact);
        }
        else
        {
            newProjectile.GetComponent<Projectile>().Initialize(target, projectileDamage, projectileSpeed);
        }

    }

}