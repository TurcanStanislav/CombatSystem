using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Rigidbody2D     m_body2d;
    public Animator         m_animator;
    public ShowText         t;
    public float            m_speed = 2.0f;
    public int              maxHealth = 1000;
    public int                     currentHealth;
    public Boolean          isAlive = true;


    // Use this for initialization
    void Start () 
    {
        currentHealth = maxHealth;
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();

        t = GameObject.FindGameObjectWithTag("TextField").GetComponent<ShowText>();
        t.ShowHP(currentHealth, "Enemy");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        t.ShowHP(currentHealth, "Enemy");

        setState("Hurt");

        if(damage >= 200) 
        {
           setState("Stunned");
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        setState("Death");
        isAlive = false;
        
        GetComponentInChildren<Collider2D>().enabled = false;
        m_body2d.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePosition;
        this.enabled = false;
    }

    void Respawn()
    {
        //Spawn a new enemy after the previous' death
    }

	// Update is called once per frame
	void Update() 
    {
        //ToChangeDirectionDependingOnPositionOfPlayer
        //if(Enemy.state = died) Respawn();
    }

    public void Move()
    {
        float horizontalMove = -0.75f * m_speed;
        //Move
        m_body2d.velocity = new Vector2(horizontalMove, m_body2d.velocity.y);
    }

    public void setState(string str)
    {
        m_animator.SetTrigger(str);
    }


}
