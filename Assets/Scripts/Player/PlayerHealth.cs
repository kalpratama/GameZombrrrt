using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar;
    public GameObject gameOverScreen;
    public GameOver gameOverScript;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI timeSpentText;

    private float timeSpent;
    private int killCount;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        timeSpent += Time.deltaTime;    
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("Took Damage");
        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        gameOverScreen.SetActive(true);
        gameOverScript.PlayerDied();
        Time.timeScale = 0f;
        killCountText.text = "Kills: " + killCount;
        timeSpentText.text = "Time Spent: " + Mathf.FloorToInt(timeSpent) + "s";
    }

    public void IncreaseKillCount()
    {
        killCount++;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0MainMenu");
    }
}