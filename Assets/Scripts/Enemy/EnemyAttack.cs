using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.5f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;
    private Transform player;
    private PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            Attack();
        }
    }

    void Attack()
    {
        Target target = GetComponent<Target>();
        if (target.isDead == false)
        {
            playerHealth.TakeDamage(damage);

        }
    }
}
