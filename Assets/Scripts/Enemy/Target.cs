using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PatrollingEnemy))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Collider))]

public class Target : MonoBehaviour
{
    public float health = 50f;
    private Animator animator;
    public bool isDead = false;
    private PatrollingEnemy enemyPatrol;
    private Target target;
    //public GameObject xpPoint;
    public GameOver gameOverScript;

    void Awake()
    {
        animator = GetComponent<Animator>();
        gameOverScript = FindObjectOfType<GameOver>();
        enemyPatrol = GetComponent<PatrollingEnemy>();
        target = GetComponent<Target>();
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
        Debug.Log("Enemy Died");

        // --- Start of Defensive Code ---

        if (gameOverScript != null)
        {
            gameOverScript.IncrementKillCount();
        }
        else
        {
            // This will tell you if the GameOver object is the problem
            Debug.LogError("CRITICAL ERROR: The 'gameOverScript' was not found in the scene!", this.gameObject);
        }

        GetComponent<Collider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        this.enabled = false;
        enemyPatrol.enabled = false;
        target.enabled = false;

        /*if (xpPoint != null)
        {
            Instantiate(xpPoint, transform.position, Quaternion.identity);
        }
        else
        {
            // This will tell you if the xpPoint prefab is the problem
            Debug.LogError("CRITICAL ERROR: The 'xpPoint' prefab was not assigned in the Inspector on " + this.gameObject.name);
        }*/

        // --- End of Defensive Code ---

        // We can delay destroying the object for a moment to ensure all effects play
        Destroy(gameObject, 2f); // Destroy after 2 seconds
    }

    /*void Die()
    {
        isDead = true;
        animator.SetTrigger("Dies");
        Debug.Log("Enemy Died");
        gameOverScript.IncrementKillCount();
        GetComponent<Collider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        this.enabled = false; // Disable this script
        enemyPatrol.enabled = false; // this is line 42
        target.enabled = false;
        Instantiate(xpPoint, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }*/
}
