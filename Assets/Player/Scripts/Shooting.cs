using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;//
    public Transform firePoint;//

    public float bulletForce = 10f;//
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
            �������� ������� ����*/
            Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();/*������ ��� ����������*/

            rg.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);/* ���������� �������� ����*/

            yield return new WaitForSecondsRealtime(shootingSpeed);// ��������� �������
        }
    }
}
