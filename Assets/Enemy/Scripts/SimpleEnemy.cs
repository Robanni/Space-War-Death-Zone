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

    public float AttackSpeed = 1;
    public float bulletForce = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
        posX = transform.position.x;
        StartCoroutine(shooting());
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
    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);/*
            создание объекта пули*/
            Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();/*взятие физ клмпоненты*/

            rg.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);/* добавление импульса пуле*/

            yield return new WaitForSecondsRealtime(AttackSpeed);// Скоррость срельбы
        }
    }

}
