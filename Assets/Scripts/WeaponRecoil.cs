using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    public float recoilAmount = 0.1f;
    public float recoilSpeed = 10f;
    private Vector3 initialPosition;
    private Vector3 recoilPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Smoothly return to the initial position
        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime * recoilSpeed);
    }

    public void Recoil()
    {
        recoilPosition = new Vector3(0, 0, -recoilAmount);
        transform.localPosition += recoilPosition;
    }
}
