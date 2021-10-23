using System;
using UnityEngine;

public class Repulsion : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Rigidbody2D enemyRB;
    Boolean player_enemy = false;
    public Boolean playerRepulsioned = false;
    //player_enemy == false => player is to the left of enemy
    //player_enemy == true => player is to the right of enemy

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerRB.position.x < enemyRB.position.x) player_enemy = false;
        else player_enemy = true;

        if(playerRepulsioned && player_enemy == false && playerRB.GetComponent<Player>().currentHealth > 0) 
            playerRB.velocity = new Vector2(playerRB.position.x - 5.0f, playerRB.position.y);
        if(playerRepulsioned && player_enemy == true  && playerRB.GetComponent<Player>().currentHealth > 0) 
            playerRB.velocity = new Vector2(playerRB.position.x + 5.0f, playerRB.position.y);

        playerRepulsioned = false;
    }
    
    public void AttackRepulsion(string name)
    {
        //Debug.Log("Player's position: " + playerRB.position.x + " " + playerRB.position.y);
        //Debug.Log("Enemy's position: " + enemyRB.position.x + " " + enemyRB.position.y);

        if(player_enemy == false && name == "Enemy" && enemyRB.GetComponent<Enemy>().currentHealth > 0) 
            enemyRB.velocity = new Vector2(enemyRB.position.x + 5.0f, enemyRB.position.y);

        if(player_enemy == true && name == "Enemy" && enemyRB.GetComponent<Enemy>().currentHealth > 0) 
            enemyRB.velocity = new Vector2(enemyRB.position.x - 5.0f, enemyRB.position.y);           
    }
}
