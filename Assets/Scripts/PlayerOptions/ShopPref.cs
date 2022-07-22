using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPref : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("HealthLevel")) PlayerPrefs.SetInt("HealthLevel", 1);
        if (!PlayerPrefs.HasKey("DamageLevel")) PlayerPrefs.SetInt("DamageLevel", 1);
        if (!PlayerPrefs.HasKey("AttackSpeedLevel")) PlayerPrefs.SetInt("AttackSpeedLevel", 1);
    }

    
}
