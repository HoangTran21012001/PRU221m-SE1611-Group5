using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject games;
    public GameObject menu;

    public void ExxitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }


    public void StartGame()
    {
        games.SetActive(true);
        menu.SetActive(false);
    }

    public void closeScreen()
    {
        games.SetActive(false);
        menu.SetActive(true);
    }
}
