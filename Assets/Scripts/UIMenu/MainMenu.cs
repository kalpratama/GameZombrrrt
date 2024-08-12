using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject objectiveScreen;
    public void PlayGame()
    {
        objectiveScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("1GameScene"); // Ensure you replace "GameScene" with your actual game scene name
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

