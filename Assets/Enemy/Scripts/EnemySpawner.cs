using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefub;
    public float intervalSpawn;
    public Transform point;

    private int counter = 0;



    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawnerEnemy(intervalSpawn, enemyPrefub));        
    }

    private void FixedUpdate()
    {
        enemySpawner2();
    }

    /*IEnumerator enemySpawner(float interval, GameObject enemy) Доработать    {
        rot = new Quaternion(0, 0, 180, 0); // x,y,z,w
        Instantiate(enemy, point.position, rot);

        yield return new WaitForSecondsRealtime(interval);
    }
    */

    private void enemySpawner2 ()
    {
        Quaternion rot = new Quaternion(0, 0, 180, 0); // x,y,z,w;
        counter += 1;
        

        if (counter >= intervalSpawn)
        {
            counter = 0;
            Instantiate(enemyPrefub, point.position, rot);
        }
    }


}