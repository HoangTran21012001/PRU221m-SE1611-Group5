using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public static bool winGame;
    public int rountWin;
    public int minLive;

    public GameObject gameOverUI;
    public GameObject winGameUI;

    void Start()
    {
        gameIsOver = false;
        winGame = false;
    }
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        if(LevelManager.Lives <= minLive)
        {
            EndGame();
        }
        if(LevelManager.Rounds == rountWin)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winGame = true;
        winGameUI.SetActive(true);
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
 