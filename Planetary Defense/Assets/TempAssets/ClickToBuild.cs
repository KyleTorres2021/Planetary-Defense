using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToBuild : MonoBehaviour
{
    [SerializeField]
    GameObject tower;

    GameObject gameManager;

    // Set sound effect to play
    [SerializeField]
    AudioClip build;

    private void Start()
    {
        // Set GameManager for use
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        build = Resources.Load<AudioClip>("TempSound/build");
    }

    private void OnMouseDown()
    {
        if (gameManager.GetComponent<GameManager>().moneyCount > 24)
        {
            SoundManager.Instance.Play(build);
            Instantiate(tower, transform.position, transform.rotation);
            gameManager.GetComponent<GameManager>().ChangeMoney(-25);
            Destroy(this.gameObject);
        }
    }
}
