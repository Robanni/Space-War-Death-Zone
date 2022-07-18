using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    private MainPlayer player;
    private int playerCurrentExp = 0;
    private int playerAllExp = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
    }

    void SaveGame()
    {
        if(!PlayerPrefs.HasKey("MaxHealth")) PlayerPrefs.SetInt("MaxHealth", 1);

        PlayerPrefs.SetInt("SavedExp", playerAllExp);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.health>0)
        { 
            playerCurrentExp = player.exp;
        }
        else
        {
            playerAllExp += playerCurrentExp;
            SaveGame();
        }
    }
}
