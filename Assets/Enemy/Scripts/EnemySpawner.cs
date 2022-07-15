using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefub;
    public float intervalSpawn;

    private float width;
    private float height;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        width = Screen.width;
        height = Screen.height;

        StartCoroutine(Spawner());        
    }
    IEnumerator Spawner()    {
        while (true)
        {
            float posX =  Random.Range(0, width);

            Vector3 pos = cam.ScreenToWorldPoint( new Vector3(posX,height,0));

            pos.z = 0;

            Instantiate(enemyPrefub, pos, transform.rotation);

            yield return new WaitForSecondsRealtime(intervalSpawn);
        }
    }
}