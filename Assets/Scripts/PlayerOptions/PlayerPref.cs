using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    private MainPlayer player;
    private int playerCurrentExp;
    private int playerAllExp = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
        if (PlayerPrefs.HasKey("SavedExp")) playerAllExp = PlayerPrefs.GetInt("SavedExp");//если есть поле XP то берем полное значение
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
        if (player.isAlive())
        {
            playerCurrentExp = player.exp;
        }
    }
    private void OnDestroy()
    {
        playerAllExp += playerCurrentExp;
        SaveGame();
    }
}
