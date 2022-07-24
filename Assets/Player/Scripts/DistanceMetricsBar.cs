using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceMetricsBar : MonoBehaviour
{
    public TextMeshProUGUI distanceMetricsBar;
    private float distance = 0;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        distance += Time.deltaTime * 5;
        distanceMetricsBar.text = Mathf.Round(distance).ToString();
        
        
    }

    public float getDistance()
    {
        return distance;
    }
}
