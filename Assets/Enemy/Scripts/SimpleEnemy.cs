using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    private float maxX = 1.77f;
    private float posY;
    private float posX;
    public float speedY = 0.1f;
    public float speedX = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x > maxX)
        {
            speedX = -speedX;   
        }
        if(transform.position.x < -maxX)
        {
            speedX =- speedX;
        }

        posX += Time.deltaTime * speedX;

        posY -= Time.deltaTime * speedY;

        transform.position = new Vector3(posX, posY, transform.position.z);
        
    }
}
