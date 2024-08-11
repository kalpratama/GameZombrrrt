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

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
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
    }
}