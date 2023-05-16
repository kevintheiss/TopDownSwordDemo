using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * A class to manage the overall game state, including UI, player health, and lives count
 */
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerMaxHealth = 100;
    [SerializeField] TextMeshProUGUI healthText; // UI text to display health

    int playerCurrentHealth;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length; // Find the number of GameSession objects in the level

        // If there is more than one GameSession object, remove the new one from the level
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }

        // Otherwise, keep the GameSession object persistent between scenes
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        playerCurrentHealth = playerMaxHealth; // Set the player's current health to max health
        healthText.text = playerCurrentHealth.ToString(); // Set the UI health text to the starting player health
    }

    /*
     * Reduce the player's health by the value passed in
     */
    public void TakeDamage(int damage)
    {
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth - damage, 0, playerMaxHealth); // Subtract damage and make sure the player's health never goes below 0
        healthText.text = playerCurrentHealth.ToString(); // Update the UI text
    }
}
