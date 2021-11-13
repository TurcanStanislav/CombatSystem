using UnityEngine;

public class CombatSystem_Enemy : MonoBehaviour
{
    public Animator animator;

    //public Transform attackPoint;
    //public LayerMask enemyLayer;
    //public float attackRange = 0.5f; 
    
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
    
    }

    void Start()
    {
        animator = GetComponent<Enemy>().GetComponentInParent<Animator>();
    }

    void Attack()
    {
        attackDamage = 40;
        animator.SetTrigger("Attack"); 
    }

}
