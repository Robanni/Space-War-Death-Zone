using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLevel : MonoBehaviour
{
    public List<GameObject> NextBackGround;
    private Vector3 CurrentPos;
    private Vector3 ScreenSettings;
    private float speed = 0.2f;
    private bool creatChild = false;

    private RectTransform  objectRect;
    // Start is called before the first frame update
    void Start()
    {
        objectRect = GetComponent<RectTransform>();
        ScreenSettings = FindObjectOfType<MainCameraScript>().ScreenSettings;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentPos = transform.position;
        CurrentPos.y -= Time.deltaTime * speed;

        gameObject.transform.position = CurrentPos;

        if(transform.position.y < 0 && !creatChild)
        {
            Vector3 newVecPos = transform.position;
            newVecPos.y = transform.position.y + 2 * objectRect.rect.height;
            Instantiate(NextBackGround[Random.Range(0,NextBackGround.Count)], newVecPos, transform.rotation);
            creatChild = true;
        }

        if(transform.position.y <-objectRect.rect.height) Destroy(gameObject);
    }
}
