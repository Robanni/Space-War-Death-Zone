using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinBar : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private MainPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
        coinText.text = player.exp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        coinText.text = player.exp.ToString();
    }
}
