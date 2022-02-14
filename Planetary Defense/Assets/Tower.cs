using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Barebones container for the absolute basics of Tower function
/// </summary>
public class Tower : MonoBehaviour
{

    // Declare Tower Stats
    public float range = 0f;
    public float buildTime = 1f;
    public int towerCost = 0;
    public int hp = 1;
    private bool boosted = false;

    // Colors for damage
    Color normalColor = new Color(1, 1, 1);
    Color damageColor = new Color(255, 0, 0);

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Helps other objects such as bullets deal damage to this tower
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        hp -= damage;

        StartCoroutine(FlashRed());
    }

    /// <summary>
    /// Enemy briefly blinks red when damaged
    /// </summary>
    /// <returns></returns>
    IEnumerator FlashRed()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = damageColor;

        yield return new WaitForSeconds(.05f);

        this.gameObject.GetComponent<SpriteRenderer>().color = normalColor;
    }


    /// <summary>
    /// Draw a circle representing range when tower is selected
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
