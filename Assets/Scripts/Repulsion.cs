using System;
using UnityEngine;

public class Repulsion : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Rigidbody2D enemyRB;
    Boolean player_enemy = false;
    public Boolean playerRepulsioned = false;
    public Boolean enemyRepulsioned = false;
    //player_enemy == false => player is to the left of enemy
    //player_enemy == true => player is to the right of enemy

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody2D>();

        if(playerRB.position.x < enemyRB.position.x) player_enemy = false;
        else player_enemy = true;


        if(playerRepulsioned && player_enemy == false && playerRB.GetComponent<Player>().currentHealth > 0) 
            playerRB.velocity = new Vector2(playerRB.position.x - 5.0f, playerRB.position.y);
        if(playerRepulsioned && player_enemy == true  && playerRB.GetComponent<Player>().currentHealth > 0) 
            playerRB.velocity = new Vector2(playerRB.position.x + 5.0f, playerRB.position.y);

        playerRepulsioned = false;


        if(player_enemy == false && enemyRepulsioned) 
        {
            enemyRB.velocity = new Vector2(enemyRB.position.x + 2.5f, enemyRB.position.y);
            GameObject.FindGameObjectWithTag("EnemyCollider").GetComponent<Enemy_AI>().stop = true;
        }
        if(player_enemy == true && enemyRepulsioned) 
        {
            enemyRB.velocity = new Vector2(enemyRB.position.x - 2.5f, enemyRB.position.y); 
            GameObject.FindGameObjectWithTag("EnemyCollider").GetComponent<Enemy_AI>().stop = true;
        }
        enemyRepulsioned = false;
    }
}
