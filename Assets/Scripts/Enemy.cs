using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int maxHealth = 100;
    int currentHealth;
    public Animator m_animator;
    public ShowText t;

    // Use this for initialization
    void Start () 
    {
        currentHealth = maxHealth;
        m_animator = GetComponent<Animator>();

        t = GameObject.FindGameObjectWithTag("TextField").GetComponent<ShowText>();
        t.ShowHP(currentHealth);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        t.ShowHP(currentHealth);

        m_animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        m_animator.SetTrigger("Death");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

	// Update is called once per frame
	void Update () 
    {
        

    }
}
