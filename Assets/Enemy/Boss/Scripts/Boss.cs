using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : BaseEnemy
{
    public List<Transform> firePoints;

    private float posY;
    private float posX;
    private float maxY;
    private float maxX;

    private float speedY = 2f;
    private float speedX = 2f;
    private float attackSpeed = 5f;

    public GameObject bulletPrefub;
    // Start is called before the first frame update
    new void Start()
    {
        Camera cam = Camera.main;
        maxY = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        maxX = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x -1f;
        health *= 2;
        expiriens *= 5;
        
        posY = transform.position.y;
        posX = transform.position.x;

        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(posY > (maxY/1.3))
        {
            posY -= Time.deltaTime * speedY; 
        }
        if(transform.position.x > maxX || transform.position.x < -maxX)
        {
            speedX = -speedX;
        }
        posX += Time.deltaTime * speedX;

        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    IEnumerator Shooting()
    {
        while(true)
        {
            Attack();
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    void Attack()
    {
        for (int i = 0; i < firePoints.Count; i++)
        {
            GameObject bullet = Instantiate(bulletPrefub.gameObject, firePoints[i].position, bulletPrefub.transform.rotation);
            bullet.transform.SetParent(gameObject.transform);
        }
    }
}

