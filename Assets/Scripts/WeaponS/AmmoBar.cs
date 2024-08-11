using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider ammoSlider;
    public PlayerShooting playerShooting;

    void Start()
    {
        // Find PlayerShooting script in the scene if not assigned
        if (playerShooting == null)
        {
            playerShooting = FindObjectOfType<PlayerShooting>();
        }

        // Set slider max value to maxAmmo from PlayerShooting script
        ammoSlider.maxValue = playerShooting.maxAmmo;
    }

    void Update()
    {
        // Update slider value based on current ammo count
        ammoSlider.value = playerShooting.currentAmmo;
    }
}
