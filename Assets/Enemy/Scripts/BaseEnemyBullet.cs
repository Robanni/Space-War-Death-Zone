using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBullet : MonoBehaviour
{
    public int damage = 1;
    public float bulletForce = 100f;
    // Start is called before the first frame update
    void Start()
    {
        damage = FindObjectOfType<BaseEnemy>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
