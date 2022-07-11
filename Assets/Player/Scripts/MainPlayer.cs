using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public int exp = 0;
    public int health = 3;

    private void Update()
    {
        if (!isAlive())
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            int damage = collision.gameObject.GetComponent<BaseEnemyBullet>().damage;
            takeDamege(damage);
            
        }
    }

    bool isAlive()
    { return health > 0; }
    void takeDamege(int damage)//получение урона
    {
        health -= damage;
    }
}
