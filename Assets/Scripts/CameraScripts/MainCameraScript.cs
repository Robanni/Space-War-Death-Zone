using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    [HideInInspector]
    public  Vector3 ScreenSettings;
    void Awake()
    {
        ScreenSettings = new Vector3 (Screen.width, Screen.height,0);
        ScreenSettings = gameObject.GetComponent<Camera>().ScreenToWorldPoint(ScreenSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
