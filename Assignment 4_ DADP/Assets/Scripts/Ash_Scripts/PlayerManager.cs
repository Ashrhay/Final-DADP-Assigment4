using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this; 
    }

    #endregion

    public GameObject player;

    public int initialHealth = 100; // Set the player's initial health
    private int currentHealth; // To track the current health
    public Text gameOverText; // Reference to the Game Over text element in your UI

    void Start()
    {
        currentHealth = initialHealth; // Initialize the current health
        UpdateHealthUI(); // Update the UI to show initial health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI(); // Update the UI to reflect the new health

        if (currentHealth <= 0)
        {
            // Player is dead - trigger game over
            GameOver();
        }
    }

    void UpdateHealthUI()
    {
        // Update the UI text to show the current health
        // Assuming you have a UI text element to display health, update it here.
        // Example: healthText.text = "Health: " + currentHealth;
    }

    void GameOver()
    {
        // Set the game over UI panel as active (visible)
        gameOverText.gameObject.SetActive(true);
        // Optionally, you can pause the game or perform other game-over-related actions here.
    }
}

