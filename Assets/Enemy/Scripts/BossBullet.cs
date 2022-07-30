using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage = 1;

    private void Start()
    {
        StartCoroutine(TimeDestruction());
    }

    IEnumerator TimeDestruction()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
