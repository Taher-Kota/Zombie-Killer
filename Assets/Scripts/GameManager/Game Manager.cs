using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject PauseBtn;
    public GameObject PausePanel;
    public GameObject UI_Holder;
    public GameObject GameOVer;
    public TextMeshProUGUI Zombies_Kill_Txt;
    public TextMeshProUGUI Gameover_Zombies_Txt;

    private int zombies_kill_count = 0;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            PausePanel.SetActive(true);
            PauseBtn.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 0)
        { 
            PauseBtn.SetActive(true);
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        UI_Holder.SetActive(false);
        GameOVer.SetActive(true);
        Gameover_Zombies_Txt.text = "Killed : "+zombies_kill_count;
        Time.timeScale = 0;
    }

    public void Zombies_Score()
    {
        zombies_kill_count++;
        Zombies_Kill_Txt.text = zombies_kill_count.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
