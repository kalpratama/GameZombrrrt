using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public Transform weapon;          // Assign the weapon transform in the inspector
    public Transform normalPosition;  // Assign the current (hip-fire) position of the weapon
    public Transform aimPosition;     // Assign the AimPosition GameObject you created
    public Camera playerCamera;       // Assign the player's camera in the inspector
    public float normalFOV = 60f;
    public float aimFOV = 40f;
    public float fovSpeed = 8f;
    public float aimSpeed = 8f;       // Speed at which the weapon transitions
    private bool isAiming = false;
    private WeaponSway weaponSway;

    void Start()
    {
        // Get the WeaponSway component attached to the weapon
        weaponSway = weapon.GetComponent<WeaponSway>();
    }

    void Update()
    {
        if (Input.GetButton("Fire2")) // Right mouse button
        {
            isAiming = true;
            
        }
        else
        {
            isAiming = false;
        }

        if (isAiming)
        {
            Aim();
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, aimFOV, Time.deltaTime * fovSpeed);
            
        }
        else
        {
            HipFire();
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, normalFOV, Time.deltaTime * fovSpeed);
        }
    }

    void Aim()
    {
        if (weaponSway != null)
        {
            weaponSway.enabled = false;
        }
        weapon.localPosition = Vector3.Lerp(weapon.localPosition, aimPosition.localPosition, Time.deltaTime * aimSpeed);
        weapon.localRotation = Quaternion.Lerp(weapon.localRotation, aimPosition.localRotation, Time.deltaTime * aimSpeed);
    }

    void HipFire()
    {
        // Enable Weapon Sway when not aiming
        if (weaponSway != null)
        {
            weaponSway.enabled = true;
        }
        weapon.localPosition = Vector3.Lerp(weapon.localPosition, normalPosition.localPosition, Time.deltaTime * aimSpeed);
        weapon.localRotation = Quaternion.Lerp(weapon.localRotation, normalPosition.localRotation, Time.deltaTime * aimSpeed);
    }
}
