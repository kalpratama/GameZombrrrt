using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI timeSpentText;

    private int killCount;
    private float timeSpent;
    private bool isGameOver = false;

    void Start()
    {
        // Ensure the game over UI is hidden at the start
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver) // Only count time if the game is not over.
        {
            timeSpent += Time.deltaTime;
        }
    }

    public void PlayerDied()
    {
        isGameOver = true;
        Debug.Log("Player DIed");
        gameOverUI.SetActive(true);
        killCountText.text = "Kills: " + killCount.ToString();
        timeSpentText.text = "Time: " + Mathf.FloorToInt(timeSpent) + "s";
        Time.timeScale = 0f; // Pause the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void IncrementKillCount()
    {
        killCount++;
        Debug.Log("Kill Count Incremented: " + killCount);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0MainMenu"); // Ensure you have a scene named "MainMenu"
    }

}

