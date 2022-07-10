using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefub;
    public float intervalSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());        
    }
    IEnumerator Spawner()    {
        while (true)
        {
            Instantiate(enemyPrefub, transform.position, transform.rotation);

            yield return new WaitForSecondsRealtime(intervalSpawn);
        }
    }
}