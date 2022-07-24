using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : BaseEnemy
{
    private float maxX;
    private float maxY;

    private float posX;
    private float posY;

    private float speedX = 3f;
    private float speedY = 2f;

    public BaseEnemyBullet BulletPrefub;
    public List<Transform> firePoint;
    private float atackSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;

        maxX = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        maxY = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        Debug.Log(maxY);

        posX = transform.position.x;
        posY = transform.position.y;

        StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x > maxX || transform.position.x < -maxX)
        {
            speedX = -speedX;
        }
        
        if(transform.position.y < maxY/2 || transform.position.y > maxY)
        {
            speedY = -speedY;
        }

        posX += Time.deltaTime * speedX;
        posY -= Time.deltaTime * speedY;

        transform.position = new Vector3(posX, posY, transform.position.z);


    }

    IEnumerator Shooting()
    {
        while(true)
        {
            for (int i = 0; i < firePoint.Count; i++)
            {
                GameObject bullet = Instantiate(BulletPrefub.gameObject, firePoint[i].position, BulletPrefub.transform.rotation);
                Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();
                rg.AddForce(firePoint[i].up * BulletPrefub.bulletForce, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(atackSpeed);
        }
    }
}
