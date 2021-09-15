using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Type of projectile equipped by this tower
    [SerializeField]
    GameObject projectileType;
    public int projectileDamage;
    public int projectileSpeed;

    //Declare Sound effects
    [SerializeField]
    AudioClip shoot;

    // Declare Tower Stats
    public float range = 5f;
    public float fireRate = 2f;
    public float fireCountdown = 0f;

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

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // If the nearest enemy is in range, it's set as the tower's target
        if(nearestEnemy != null && shortestDistance <= range)
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
        if(target == null)
        {
            return;
        }

        // Controls rate of fire
        if(fireCountdown <= 0f)
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

        // Pass along projectile's target, damage, and speed
        newProjectile.GetComponent<Projectile>().Initialize(target, 5, 15);
    }

    /// <summary>
    /// Draw a circle representing range when tower is selected
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
