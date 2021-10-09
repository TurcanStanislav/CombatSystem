using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    CombatSystem combatSystem;

    private void Start()
    {
        combatSystem = GetComponentInParent<CombatSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("Attacking " + collider.name);
        collider.GetComponent<Enemy>().TakeDamage(combatSystem.attackDamage);
    }


}
