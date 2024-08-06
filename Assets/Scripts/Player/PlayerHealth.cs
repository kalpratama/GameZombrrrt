using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthBar;
    public GameObject gameOverScreen;
    public Text killCountText;
    public Text timeSpentText;

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
        SceneManager.LoadScene("2GameOver");
        gameOverScreen.SetActive(true);
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