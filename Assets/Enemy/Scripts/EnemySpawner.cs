using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float intervalSpawn;
    [SerializeField]
    public List<GameObject> enemyPrefubArr;

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
            float posX =  Random.Range(0, width);//рандомная позиция Х врага через размер экрана
            int typeOfEnemy = Random.Range(0, enemyPrefubArr.Count);

            Vector3 pos = cam.ScreenToWorldPoint( new Vector3(posX,height,0));//вектор с рандомным Х и У у верха экрана
            pos.z = 0;

            Instantiate(enemyPrefubArr[typeOfEnemy] , pos, enemyPrefubArr[typeOfEnemy].transform.rotation);

            yield return new WaitForSeconds(intervalSpawn);
        }
    }
}