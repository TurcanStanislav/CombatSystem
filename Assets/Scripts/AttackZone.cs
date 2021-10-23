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
        if(collider.name == "EnemyCollider" && GetComponentInParent<CombatSystem>().isAttacking == true) collider.GetComponentInParent<Enemy>().TakeDamage(combatSystem.attackDamage);
        if(collider.GetComponentInParent<Enemy>().currentHealth > 0 && collider.name == "EnemyCollider") GetComponentInParent<Repulsion>().AttackRepulsion(id);
        GameObject.FindGameObjectWithTag("EnemyCollider").GetComponent<Enemy_AI>().stop = true;
    }

}
