using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Homing : Projectile
{
    //private Transform targetTransform;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FindTarget());
    }

    IEnumerator FindTarget()
    {
        yield return new WaitForSeconds(.5f);
        myTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    //void Update()
    //{
    //    if(myTarget == null)
    //    {
    //        myTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
    //    }
    //    else
    //    {
    //        Vector3 normalizeDirection = (myTarget.position - transform.position).normalized;
    //        transform.position += normalizeDirection * mySpeed * Time.deltaTime;
    //    }
    //}
}
