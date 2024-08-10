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

    void Update()
    {
        timeSpent += Time.deltaTime;
    }

    public void PlayerDied()
    {
        gameOverUI.SetActive(true);
        killCountText.text = "Kills: " + killCount.ToString();
        timeSpentText.text = "Time: " + Mathf.FloorToInt(timeSpent) + "s";
        Time.timeScale = 0f; // Pause the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

    public void IncrementKillCount()
    {
        killCount++;
        Debug.Log("Kill Count Incremented: " + killCount);
    }
}

