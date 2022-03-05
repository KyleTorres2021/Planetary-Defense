using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_En : Projectile
{

    // Called when a collision is registered
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If colliding with an enemy, damage it and destroy this projectile
        if (collision.gameObject.tag == "Tower") // I'll leave this here since projectiles can collide with asteroids
        {
            collision.gameObject.GetComponent<HealthBar>().Damage(myDamage);

            // Plays special hit sound if there is one.
            if (mySound != null)
            {
                SoundManager.Instance.Play(mySound);
            }

        }

        // Spawn impact effect and destroy prefab
        Instantiate(impactParticle, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

}
