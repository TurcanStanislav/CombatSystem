using UnityEngine;

public class AttackZone : MonoBehaviour
{
    CombatSystem combatSystem;
    string id = "Enemy";

    private void Start()
    {
        combatSystem = GetComponentInParent<CombatSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("Attacking " + collider.name);
        if(collider.name == "EnemyCollider" && GetComponentInParent<CombatSystem>().isAttacking == true) 
            collider.GetComponentInParent<Enemy>().TakeDamage(combatSystem.attackDamage); 
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.GetComponentInParent<Enemy>().currentHealth > 0 && collider.name == "EnemyCollider") 
            GameObject.FindGameObjectWithTag("Player").GetComponent<Repulsion>().enemyRepulsioned = true;  
    }

}
