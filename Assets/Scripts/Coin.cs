using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10;
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TurtleKnight_Pixel"))
        {
            //play sound effect
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            //increment score
            ScoreManager.instance.AddScore(scoreValue);

            //destroy coin
            Destroy(gameObject);
        }
    }
}
