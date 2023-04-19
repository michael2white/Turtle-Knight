using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    public Image heart1;
    public Image heart2;
    public Image heart3;

    private void Start()
    {
        currentHealth = maxHealth;   

        // Assign the Image components for the hearts in GameUI
        heart1 = GameObject.Find("GameUI/Heart1").GetComponent<Image>();
        heart2 = GameObject.Find("GameUI/Heart2").GetComponent<Image>();
        heart3 = GameObject.Find("GameUI/Heart3").GetComponent<Image>();
    }

    void Update()
    {
        // Update the hearts on the game UI based on the player's current health
        switch (currentHealth)
        {
            case 3:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = true;
                break;
            case 2:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
                break;
            case 1:
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
            case 0:
                heart1.enabled = false;
                heart2.enabled = false;
                heart3.enabled = false;
                break;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // If the player's health reaches zero, respawn the player
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            // Call a respawn function here
        }
    }
    
}
