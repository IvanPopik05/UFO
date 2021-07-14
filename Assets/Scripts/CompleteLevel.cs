using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private string NextLevel = "Level02";
    [SerializeField] float NextLevelIndex = 2;
    [SerializeField] string MainMenu = "MainMenu";

    public void Continue()
    {
        PlayerPrefs.SetFloat("levelReached", NextLevelIndex);
        sceneFader.FadeTo(NextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(MainMenu);
    }
}
