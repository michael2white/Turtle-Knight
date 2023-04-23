using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPNoAudio : MonoBehaviour
{
    public int damage = 1; //Amount of dmg inflicted on contact

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurtleKnight_Pixel"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); 
            }
        }
    }
}
