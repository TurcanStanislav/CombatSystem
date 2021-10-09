using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f; 
    public int attackDamage = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Attack();       
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
/*
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

*/    
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
            
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
       
}
