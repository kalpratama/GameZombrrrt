using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("1GameScene"); // Ensure you replace "GameScene" with your actual game scene name
    }

    public void ShowCredits()
    {
        // Implement your logic for showing credits
        Debug.Log("Credits Button Clicked");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
