﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Stats to be copied to
    Transform myTarget;
    float mySpeed;
    int myDamage;
    AudioClip mySound;

    //
    Vector3 normalizeDirection;

    public void Initialize(Transform target, int damage, float speed)
    {
        // Set projectile stats based on what created it
        myTarget = target;
        myDamage = damage;
        mySpeed = speed;

        // Find direction at spawn bullet should fly in
        normalizeDirection = (target.position - transform.position).normalized;
    }

    /// <summary>
    /// Overload for projectiles with special hit sounds
    /// </summary>
    /// <param name="target"></param>
    /// <param name="damage"></param>
    /// <param name="speed"></param>
    /// <param name="hitSound"></param>
    public void Initialize(Transform target, int damage, float speed, AudioClip hitSound)
    {
        // Set projectile stats based on what created it
        myTarget = target;
        myDamage = damage;
        mySpeed = speed;
        mySound = hitSound;

        // Find direction at spawn bullet should fly in
        normalizeDirection = (target.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //Move bullet in set direction
        transform.position += normalizeDirection * mySpeed * Time.deltaTime;
    }

    // Called when a collision is registered
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If colliding with an enemy, damage it and destroy this projectile
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BasicEnemy>().Damage(myDamage);

            // Plays special hit sound if there is one.
            if(mySound != null)
            {
                SoundManager.Instance.Play(mySound);
            }

        }

        Destroy(this.gameObject);
    }
}
