using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with the name of your game scene
    }

    public void ShowCredits()
    {
        // Show credits, or load a credits scene
        SceneManager.LoadScene("CreditsScene"); // Replace with the name of your credits scene if you have one
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
