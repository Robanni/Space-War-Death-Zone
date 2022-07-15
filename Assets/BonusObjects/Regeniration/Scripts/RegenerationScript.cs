using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerationScript : MonoBehaviour
{
    private MainPlayer player;
    private Vector3 pos;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
        pos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yMovement = speed * Time.deltaTime;
        pos.y -= yMovement;
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            player.health++;
            Destroy(gameObject);
        }
    }
}
