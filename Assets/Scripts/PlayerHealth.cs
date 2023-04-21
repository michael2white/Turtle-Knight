using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Image blackHeart1;
    public Image blackHeart2;
    public Image blackHeart3;

    private void Start()
    {
        currentHealth = maxHealth;   

        // Assign the Image components for the hearts in GameUI
        heart1 = GameObject.Find("GameUI/Heart1").GetComponent<Image>();
        heart2 = GameObject.Find("GameUI/Heart2").GetComponent<Image>();
        heart3 = GameObject.Find("GameUI/Heart3").GetComponent<Image>();

         // Assign the Image components for the black hearts in GameUI
        blackHeart1 = GameObject.Find("GameUI/BlackHeart1").GetComponent<Image>();
        blackHeart2 = GameObject.Find("GameUI/BlackHeart2").GetComponent<Image>();
        blackHeart3 = GameObject.Find("GameUI/BlackHeart3").GetComponent<Image>();
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
                blackHeart1.enabled = false;
                blackHeart2.enabled = false;
                blackHeart3.enabled = false;
                break;
            case 2:
                heart1.enabled = true;
                heart2.enabled = true;
                heart3.enabled = false;
                blackHeart1.enabled = false;
                blackHeart2.enabled = false;
                blackHeart3.enabled = true;
                break;
            case 1:
                heart1.enabled = true;
                heart2.enabled = false;
                heart3.enabled = false;
                blackHeart1.enabled = false;
                blackHeart2.enabled = true;
                blackHeart3.enabled = true;
                break;
            case 0:
                heart1.enabled = false;
                heart2.enabled = false;
                heart3.enabled = false;
                blackHeart1.enabled = true;
                blackHeart2.enabled = true;
                blackHeart3.enabled = true;
                break;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // If the player's health reaches zero, sends to game over screen
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("End Screen");
        }
    }
    
}
