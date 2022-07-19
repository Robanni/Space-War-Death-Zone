using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public int damage = 2;
    public float speed = 1f;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos.y -= speed* Time.deltaTime;
        transform.position = pos;

        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<MainPlayer>().health -= damage;
            Destroy(gameObject);
        }
    }
}
