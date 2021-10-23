using System;
using UnityEngine;

public class AttackZone_Enemy : MonoBehaviour
{
    CombatSystem_Enemy combatSystem_Enemy;
    string id = "Player";

    // Start is called before the first frame update
    void Start()
    {
        combatSystem_Enemy = GetComponentInParent<CombatSystem_Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("Attacking " + collider.name);
        if(collider.name == "InterractZone") collider.GetComponentInParent<Player>().TakeDamage(combatSystem_Enemy.attackDamage);
        if(collider.GetComponentInParent<Player>().currentHealth > 0) GetComponentInParent<Repulsion>().AttackRepulsion(id);
    }

}
