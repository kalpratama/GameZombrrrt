using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTrigger : MonoBehaviour
{
    public int requiredScore = 2; // Set this to the score needed to trigger the checkpoint
    public TextMeshProUGUI checkpointText; // Reference to the UI Text
    public GameObject winCanvas; // Reference to the Win Canvas or GameWinPanel
    private ScoreManager scoreManager;

    private int currentScore;

    void Start()
    {
        checkpointText.gameObject.SetActive(false); // Hide text initially
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene
        winCanvas.SetActive(false); // Ensure the win screen is hidden initially
    }

    public void UpdateScore(int score)
    {
        currentScore = score;

        if (currentScore >= requiredScore)
        {
            ShowCheckpointMessage();
        }
    }

    void ShowCheckpointMessage()
    {
        checkpointText.gameObject.SetActive(true); // Show the message
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && scoreManager.score >= requiredScore)
        {
            // Player has reached the checkpoint after getting enough score
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winCanvas.SetActive(true); // Activate the win screen
        Time.timeScale = 0f; // Pause the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
