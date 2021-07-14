using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelSelect = "LevelScene";
    public SceneFader sceneFader;
    public void ButtonPlay()
    {
        sceneFader.FadeTo(levelSelect);
    }
    public void ButtonExit()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
