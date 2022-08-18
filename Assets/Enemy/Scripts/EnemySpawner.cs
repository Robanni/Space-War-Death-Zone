using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float intervalSpawn;
    [SerializeField]
    public List<GameObject> enemyPrefubArr;
    public List<GameObject> bossEnemyPrefubArr;
    private GameObject boss;
    private int[] bossSpawnPosition;

    private float width;
    private float height;
    private Camera cam;

    private bool isBossOnMap = false;

    private DistanceMetricsBar playerMetric;

    // Start is called before the first frame update
    void Start()
    {
        bossSpawnPosition = new int[2] {200,250};
        cam = Camera.main;
        width = Screen.width;
        height = Screen.height;

        playerMetric = FindObjectOfType<DistanceMetricsBar>();

        StartCoroutine(Spawner());        
    }
    IEnumerator Spawner()    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            if (!isBossOnMap)
            {
                float posX = Random.Range(0, width);//рандомная позиция Х врага через размер экрана
                int typeOfEnemy = Random.Range(0, enemyPrefubArr.Count);

                Vector3 pos = cam.ScreenToWorldPoint(new Vector3(posX, height, 0));//вектор с рандомным Х и У у верха экрана
                pos.z = 0;

                Instantiate(enemyPrefubArr[typeOfEnemy], pos, enemyPrefubArr[typeOfEnemy].transform.rotation);

                yield return new WaitForSeconds(intervalSpawn);
            }
            yield return new WaitForSeconds(2);
        }
    }

    private void FixedUpdate()
    {
        float curPlayerPos = playerMetric.getDistance();
        if(curPlayerPos > bossSpawnPosition[0] && curPlayerPos < bossSpawnPosition[1] && !isBossOnMap)
        {
            isBossOnMap = true;

            Vector3 pos = cam.ScreenToWorldPoint(new Vector3(0, height, 0));//вектор с рандомным Х и У у верха экрана
            pos.z = 0;
            pos.x = 0;

            if(curPlayerPos > 1500)
            {
                int bossNumber = Random.Range(0, bossEnemyPrefubArr.Count);
                boss = Instantiate(bossEnemyPrefubArr[bossNumber], pos, bossEnemyPrefubArr[bossNumber].transform.rotation);
            }else boss = Instantiate(bossEnemyPrefubArr[0], pos, bossEnemyPrefubArr[0].transform.rotation);

            bossSpawnPosition[0] += 500;//увеличение последующей точки спавна босса
            bossSpawnPosition[1] += 500;

            return;
        }
        if (!boss)isBossOnMap = false;
        
    }
}