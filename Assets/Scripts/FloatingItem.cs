using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // How much the item floats up and down
    public float floatSpeed = 1f; // How fast the item floats up and down
    public float rotationSpeed = 50f; // How fast the item rotates

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Floating up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotating
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
