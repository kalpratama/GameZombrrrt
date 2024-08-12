using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointTrigger : MonoBehaviour
{
    public GameObject winCanvas; // Reference to the win canvas

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
