using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public int exp = 0;
    [HideInInspector]
    public int health = 1;

    private void Start()
    {
        if(PlayerPrefs.HasKey("MaxHealth"))health = PlayerPrefs.GetInt("MaxHealth");//Берем значение максимального хп
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

    public bool isAlive()
    { return health > 0; }
    void takeDamege(int damage)//получение урона
    {
        health -= damage;
    }
}
