using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    public int health = 1;
    [HideInInspector]
    public int expiriens = 1;
    [SerializeField]
    public int  damage = 1;
    
    public DistanceMetricsBar distance;

    protected void Start()
    {
        distance = FindObjectOfType<DistanceMetricsBar>();
        if (distance.getDistance() >= 300)
        {
            health += Mathf.RoundToInt(distance.getDistance() / 300);
            damage += Mathf.RoundToInt(distance.getDistance() / 500);
            expiriens += Mathf.RoundToInt(distance.getDistance() / 500);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(!isAlive())
        {
            Destroy(gameObject);
            FindObjectOfType<MainPlayer>().exp += expiriens;
        }
        
        if(transform.position.y < 0f)//”ничтожает объект если он ниже карты
        {
            Destroy(gameObject);
        }
        
        
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            int damage = collision.gameObject.GetComponent<PlayerBullet>().damage;//коллизи€ урона
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
