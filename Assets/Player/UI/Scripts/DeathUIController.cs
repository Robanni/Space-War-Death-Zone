using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIController : MonoBehaviour
{
    public GameObject deathPanel;
    private MainPlayer player;
    private void Start()
    {
        deathPanel.SetActive(false);
        player = FindObjectOfType<MainPlayer>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(!player.isAlive())
        {
            Time.timeScale = 0;
            deathPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level_1");
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
