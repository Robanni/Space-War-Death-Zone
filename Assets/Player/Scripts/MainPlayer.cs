using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public int exp = 0;
    [HideInInspector]
    public int health = 0;
    private void Start()
    {
        health = PlayerPrefs.GetInt("HealthLevel") + 1;
    }

    private void Update()
    {
        if (!isAlive())
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag( "EnemyBullet"))
        {
            int damage = collision.gameObject.GetComponent<BaseEnemyBullet>().damage;

            takeDamege(damage);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BossBullet"))
        {
            int damage = collision.gameObject.GetComponent<BossBullet>().damage;

            takeDamege(damage);
        }
    }

    public bool isAlive()
    { return health > 0; }

    void takeDamege(int damage)//��������� �����
    {
        health -= damage;
    }


}
