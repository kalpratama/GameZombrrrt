using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponRecoil : MonoBehaviour
{
    public Transform recoilPivot;  // The object that will be rotated for recoil (e.g., Camera or Weapon).
    public float recoilAmount = 5f;  // How much the weapon recoils.
    public float recoilSpeed = 10f;  // How quickly the recoil is applied.
    public float returnSpeed = 20f;  // How quickly the weapon returns to the original position.

    private Vector3 originalRotation;

    void Start()
    {
        // Save the original rotation
        originalRotation = recoilPivot.localEulerAngles;
    }

    public void ApplyRecoil()
    {
        // Add recoil
        Vector3 recoilRotation = new Vector3(-recoilAmount, Random.Range(-recoilAmount, recoilAmount), 0f);
        recoilPivot.localEulerAngles += recoilRotation;
    }

    void Update()
    {
        // Smoothly return to the original rotation
        recoilPivot.localEulerAngles = Vector3.Lerp(recoilPivot.localEulerAngles, originalRotation, returnSpeed * Time.deltaTime);
    }
}
