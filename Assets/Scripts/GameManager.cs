using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject NextLevel;

    public void GameIsOver()
    {
        GameOver.SetActive(true);
        NextLevel.SetActive(false);
    }
    public void NextIsLevel()
    {
        NextLevel.SetActive(true);
        GameOver.SetActive(false);
    }
}
