using System;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Animator animator;

    //public Transform attackPoint;
    //public LayerMask enemyLayer;
    //public float attackRange = 0.5f; 
    
    public Boolean isAttacking = false;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Player>().isAlive)
        {    
            if (Input.GetKeyDown(KeyCode.Space))
                Attack(); 
            if(Input.GetKeyDown(KeyCode.LeftShift))
                PowerAttack();      
        }
    }

    void Attack()
    {
        attackDamage = 40;
        animator.SetTrigger("Attack");
        // Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // foreach(Collider2D enemy in hitEnemies)
        // {
        //     enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        // }    
    }
    
    void PowerAttack()
    {
        attackDamage = 200;
        animator.SetTrigger("PowerAttack");
    }

    public void StopMotion()
    {
        GetComponentInParent<Player>().stop = true;
    }

    public void StartMotion()
    {
        GetComponentInParent<Player>().stop = false;
    }

    // void OnDrawGizmosSelected()
    // {
    //     if (attackPoint == null)
    //         return;
            
    //     Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    // }
       
}
