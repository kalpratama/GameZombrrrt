using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 1; // The value to increase the score by

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            Debug.Log("Picked up item with score value: " + scoreValue);
            // Increase the player's score
            ScoreManager.instance.AddScore(scoreValue);

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
