using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Stats to be copied to
    protected Transform myTarget;
    protected float mySpeed;
    protected int myDamage;
    protected AudioClip mySound;

    //
    Vector3 normalizeDirection;

    // Impact Particles to juice projectiles a bit
    [SerializeField]
    protected GameObject impactParticle;

    public void Initialize(Transform target, int damage, float speed)
    {
        // Set projectile stats based on what created it
        myTarget = target;
        myDamage = damage;
        mySpeed = speed;

        // Find direction at spawn bullet should fly in
        normalizeDirection = (target.position - transform.position).normalized;

        // Limit bullet lifetime
        StartCoroutine("Lifetime");
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

    // Destry bullet after x time to clean up
    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(8);

        Destroy(this.gameObject);
    }

}
