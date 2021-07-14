using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIsPaused : MonoBehaviour
{
    static bool GameIsPause = false;
    public GameObject UIMenu;
    public SceneFader sceneFader;
    public string MainIsMenu = "MainMenu";
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        UIMenu.SetActive(false);
    }
    public void Pause()
    {
        GameIsPause = true;
        Time.timeScale = 0f;
        UIMenu.SetActive(true);
    }
    public void MainMenu()
    {
        sceneFader.FadeTo(MainIsMenu);
    }
}
