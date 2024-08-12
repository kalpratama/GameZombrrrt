using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 1; // The value to increase the score by
    public AudioClip pickupSound; // The sound effect for picking up the item
    public GameObject pickupEffect; // Optional: Add a visual effect for pickup

    private AudioSource audioSource;
    private ScoreManager scoreManager;
    private ScoreTrigger scoreTrigger;

    void Start()
    {
        // Get the AudioSource component if you added it to the object
        audioSource = gameObject.AddComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreTrigger = FindObjectOfType<ScoreTrigger>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding is the player
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            Debug.Log("Picked up item with score value: " + scoreValue);
            // Increase the player's score
            ScoreManager.instance.AddScore(scoreValue); 
            scoreTrigger.UpdateScore(scoreManager.score);

            // Play pickup sound
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Optional: Instantiate pickup effect
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
