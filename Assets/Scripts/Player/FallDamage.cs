using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float fallThreshold = -10f; // Minimum Y-velocity for damage to occur
    public int maxFallDamage = 50;     // Maximum damage to deal

    private Rigidbody rb;
    private bool isGrounded;
    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // If the player is grounded and the downward speed is high, apply damage
        if (isGrounded && rb.velocity.y < fallThreshold)
        {
            ApplyFallDamage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void ApplyFallDamage()
    {
        int damage = Mathf.RoundToInt(Mathf.Abs(rb.velocity.y) / Mathf.Abs(fallThreshold) * maxFallDamage);
        damage = Mathf.Clamp(damage, 0, maxFallDamage);

        playerHealth.TakeDamage(damage);

        Debug.Log($"Fall damage taken: {damage}, Player Health: {playerHealth.currentHealth}");
    }
}

