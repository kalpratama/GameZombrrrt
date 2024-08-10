using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperience : MonoBehaviour
{
    public int currentXP = 0;
    public TextMeshProUGUI xpText; // Reference to the UI Text component

    public void AddXP(int amount)
    {
        currentXP += amount;
        UpdateXPText();
    }

    void UpdateXPText()
    {
        xpText.text = "XP: " + currentXP.ToString();
    }
}
