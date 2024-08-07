using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swayAmount = 0.05f;
    public float maxSwayAmount = 0.1f;
    public float swaySmoothValue = 4f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        float movementX = -Input.GetAxis("Mouse X") * swayAmount;
        float movementY = -Input.GetAxis("Mouse Y") * swayAmount;

        movementX = Mathf.Clamp(movementX, -maxSwayAmount, maxSwayAmount);
        movementY = Mathf.Clamp(movementY, -maxSwayAmount, maxSwayAmount);

        Vector3 finalPosition = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * swaySmoothValue);
    }
}
