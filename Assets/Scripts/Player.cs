using System;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private Animator        m_animator;
    private Rigidbody2D     m_body2d;
    public ShowText         t;
    public float            m_speed = 2.0f;
    public int              maxHealth = 1000;
    public int              currentHealth;
    public Boolean          stop = false;
    public Boolean          isAlive = true;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();

        t = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<ShowText>();
        t.ShowHP(currentHealth, "Player");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        t.ShowHP(currentHealth, "Player");

        setState("Hurt");

        // if(damage >= 200) 
        // {
        //    setState("Stunned");
        // }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        setState("Death");
        stop = true;
        isAlive = false;
        
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach(Collider2D x in colliders)
        {
            x.enabled = false;
        }
        m_body2d.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePosition;
        this.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        if(!stop)
        {
            // Move
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

            // -- Handle Animations --
            //Run
            if (Mathf.Abs(inputX) > Mathf.Epsilon)
                m_animator.SetInteger("AnimState", 0);

            //Idle
            else
                m_animator.SetInteger("AnimState", 2);
        }
       // m_body2d.velocity = new Vector2(m_body2d.position.x + 5.0f, m_body2d.position.y);
    }

    public void setState(string str)
    {
        m_animator.SetTrigger(str);
    }
}

