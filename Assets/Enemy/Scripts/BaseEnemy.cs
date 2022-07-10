using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    protected int health = 1;
    [SerializeField]
    protected int expiriens = 1;

    // Update is called once per frame
    void Update()
    {
        if(!isAlive())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            int damage = collision.gameObject.GetComponent<PlayerBullet>().damege;
            takeDamege(damage);
        }
    }

    bool isAlive()
        { return health > 0; }
    void takeDamege(int damage)
    {
        health -= damage;
    }
}
