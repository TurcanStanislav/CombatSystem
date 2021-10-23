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
        if(collider.name == "EnemyCollider") collider.GetComponentInParent<Enemy>().TakeDamage(combatSystem.attackDamage);
        if(collider.GetComponentInParent<Enemy>().currentHealth > 0) GetComponentInParent<Repulsion>().AttackRepulsion(id);
    }

}
