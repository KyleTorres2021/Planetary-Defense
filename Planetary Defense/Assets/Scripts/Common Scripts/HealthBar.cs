using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //Public health to be set in editor
    public float hp = 0;

    // Serialize fields for sound effects
    //[SerializeField]
    //AudioClip damageSound;
    [SerializeField]
    AudioClip deathSound;

    // Serialize field for damage effect
    [SerializeField]
    GameObject damagedEffects;

    // Serialize fields for death particles
    [SerializeField]
    GameObject deathParticles1;
    [SerializeField]
    GameObject deathParticles2;

    // Colors for damage
    Color normalColor = new Color(1, 1, 1);
    Color damageColor = new Color(255, 0, 0);

    // TODO: Implement individual lifebard


    private void Start()
    {
        //Deactivate damaged until needed
        damagedEffects.SetActive(false);
    }

    /// <summary>
    /// Helps other objects such as bullets deal damage to this enemy
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        // immediately subtrack damage from health
        hp -= damage;

        // Perform death stuff if no HP left
        if(hp <= 0)
        {
            SoundManager.Instance.Play(deathSound);
            Instantiate(deathParticles1, transform.position, transform.rotation);
            Instantiate(deathParticles2, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
 
        StartCoroutine(FlashRed());

        if(hp <= 4)
        {
            damagedEffects.SetActive(true);
        }
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
