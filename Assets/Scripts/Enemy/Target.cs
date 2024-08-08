using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    private Animator animator;
    public bool isDead = false;
    private PatrollingEnemy enemyPatrol;
    public Target target;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Dies");
        GetComponent<Collider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        this.enabled = false; // Disable this script
        enemyPatrol.enabled = false;
        target.enabled = false;

        //Destroy(gameObject);
    }
}
