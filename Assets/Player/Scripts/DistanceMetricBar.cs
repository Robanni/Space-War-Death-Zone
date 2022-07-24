using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceMetricBar : MonoBehaviour
{
    public TextMeshProUGUI distanceMetricsBar;
    private float distance;

    // Update is called once per frame
    void FixedUpdate()
    {
        distance += Time.deltaTime * 5;
        distanceMetricsBar.text = Mathf.Round(distance).ToString();
    }
}
