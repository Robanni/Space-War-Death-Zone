using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    public int damage = 1;

    private void Start()
    {
        damage = 1/PlayerPrefs.GetInt("AttackSpeedLevel");
    }
    void Update()
    {
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")Destroy(gameObject);
    }
}
