using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;//
    public Transform firePoint;//

    private float bulletForce = 0.15f;//
    public float shootingSpeed = 1;//

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(shooting());
    }

    IEnumerator shooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);/*
            создание объекта пули*/
            Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();/*взятие физ клмпоненты*/

            rg.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);/* добавление импульса пуле*/

            yield return new WaitForSecondsRealtime(shootingSpeed);// Скоррость срельбы
        }
    }
}
