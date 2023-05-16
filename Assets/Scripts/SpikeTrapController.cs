using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A controller class to manage the behavior of spike traps
 */
public class SpikeTrapController : MonoBehaviour
{
    [SerializeField] int spikeDamage = 10;

    GameSession gameSession;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player touches the spike trap, take damage
        if(other.tag == "Player")
        {
            gameSession.TakeDamage(spikeDamage);
        }
    }
}
