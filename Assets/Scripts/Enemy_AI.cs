using System;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public AttackZone_Enemy attackZone_Enemy;
    Boolean onCollision = false;
    public Boolean stop = false;
    float time = 2.0f;
    float timeToAttack = 2.0f;

    private void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        onCollision = true;
        time += Time.deltaTime;
        if(time >= timeToAttack) 
        {
            GetComponentInParent<Enemy>().setState("Attack");
            time = 0;
        }
        if(time != timeToAttack)
            GetComponentInParent<Enemy>().setState("Idle");
        //GetComponentInParent<Enemy>().setState("Idle");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        onCollision = false;
        //stop = false;
    }


    void Update()
    {
        if(GetComponentInParent<Enemy>().isAlive && FindObjectOfType<Player>().isAlive && !stop)
            if(!onCollision)
            {
                Debug.Log("BBBBBBBBBBBBBBBBBBBB");
                GetComponentInParent<Enemy>().Move();
                GetComponentInParent<Enemy>().setState("Run");
            }
    }

}
