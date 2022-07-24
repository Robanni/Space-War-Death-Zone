using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPref : MonoBehaviour
{
    private MainPlayer player;
    private int playerCurrentExp;
    private int playerAllExp = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MainPlayer>();
        if (PlayerPrefs.HasKey("Coins")) playerAllExp = PlayerPrefs.GetInt("Coins");//���� ���� ���� XP �� ����� ������ ��������
    }

    void SaveGame()
    {
        if(!PlayerPrefs.HasKey("HealthLevel")) PlayerPrefs.SetInt("HealthLevel", 1);

        PlayerPrefs.SetInt("Coins", playerAllExp);
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
