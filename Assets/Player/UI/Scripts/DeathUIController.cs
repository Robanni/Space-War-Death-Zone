using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIController : MonoBehaviour
{
    public GameObject deathPanel;
    public MainPlayer player;
    public MainPlayer playerRespawnPrefub;
    private void Start()
    {
        deathPanel.SetActive(false);
        
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

    private IEnumerator Respawn()
    {

        player =Instantiate(playerRespawnPrefub, new Vector3(0, 1.14f, 0), playerRespawnPrefub.transform.rotation);
        

        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1;
    }

    public void GetRespawn()
    {
        StartCoroutine(Respawn());
        deathPanel.SetActive(false);
    }

}
