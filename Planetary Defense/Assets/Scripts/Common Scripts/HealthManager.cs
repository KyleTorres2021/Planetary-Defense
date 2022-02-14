using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public float hp = 0;

    // Colors for damage
    Color normalColor = new Color(1, 1, 1);
    Color damageColor = new Color(255, 0, 0);

    /// <summary>
    /// Helps other objects such as bullets deal damage to this enemy
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
}
