using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public static bool winGame;

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
        if(LevelManager.Lives <= 0)
        {
            EndGame();
        }
        if(LevelManager.Rounds == 6)
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
 