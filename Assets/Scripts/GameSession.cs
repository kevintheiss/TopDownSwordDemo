using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerHealth = 100; // Player starting health
    [SerializeField] TextMeshProUGUI healthText; // UI text to display health

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
        healthText.text = playerHealth.ToString(); // Set the UI health text to the starting player health
    }
}
