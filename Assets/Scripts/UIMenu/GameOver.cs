using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMesh killCountText;
    public Text timeSpentText;

    private int killCount;
    private float timeSpent;

    void Update()
    {
        timeSpent += Time.deltaTime;
    }

    public void PlayerDied()
    {
        gameOverUI.SetActive(true);
        killCountText.text = "Kills: " + killCount;
        timeSpentText.text = "Time: " + Mathf.FloorToInt(timeSpent) + "s";
        Time.timeScale = 0f; // Pause the game
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ensure you have a scene named "MainMenu"
    }

    public void IncrementKillCount()
    {
        killCount++;
    }
}

