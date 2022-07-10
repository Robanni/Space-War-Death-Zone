using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    protected int health = 1;
    [SerializeField]
    protected int expiriens = 1;
    [SerializeField]
    protected int damage = 1;

    // Update is called once per frame
    void Update()
    {
        if(!isAlive())
        {
            Destroy(gameObject);
            FindObjectOfType<MainPlayer>().exp += expiriens;
        }
        
        if(transform.position.y < -7f)//”ничтожает объект если он ниже карты
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            int damage = collision.gameObject.GetComponent<PlayerBullet>().damege;//коллизи€ урона
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
