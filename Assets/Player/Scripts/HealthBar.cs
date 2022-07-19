using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private MainPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
        textMeshPro.text = (player.health).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;

        if (player.health >= 0) textMeshPro.text = (player.health).ToString();
        else textMeshPro.text = "0";
    }
}
