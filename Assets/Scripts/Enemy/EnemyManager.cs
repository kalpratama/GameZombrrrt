using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies; // Array to store all enemy types
    public GameObject winCanvas; // Reference to the win canvas

    void Start()
    {
        winCanvas.SetActive(false);
    }

    void Update()
    {
        UpdateEnemyList();
        if (AllEnemiesDefeated())
        {
            ShowWinScreen();
        }
    }

    void UpdateEnemyList()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Continuously update the enemies array
    }

    bool AllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                return false;
            }
        }
        return true;
    }

    void ShowWinScreen()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
