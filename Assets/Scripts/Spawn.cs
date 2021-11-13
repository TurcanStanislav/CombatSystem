using System;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public void Respawn()
    {
        var _ = (GameObject)Instantiate(enemy, new Vector3(enemy.transform.position.x+5, enemy.transform.position.y, 0), enemy.transform.rotation);
    }

    void Start()
    {
        var _ = (GameObject)Instantiate(enemy, new Vector3(enemy.transform.position.x+5, enemy.transform.position.y, 0), enemy.transform.rotation);
    }
}
