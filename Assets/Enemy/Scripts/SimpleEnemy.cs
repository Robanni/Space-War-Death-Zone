using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    private float maxX = 1.77f;
    private float posY;
    public float speedY = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Mathf.PingPong(Time.time, maxX);

        posY -= Time.deltaTime * speedY;

        transform.position = new Vector3(x, posY, transform.position.z);
        
    }
}
