using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour, IDataPersistenceManager 
{
    public Text roundsText;

    private void OnEnable()
    {
        if (LevelManager.Rounds <= 1)
        {
            roundsText.text = "0";
        }
        else
        {
            roundsText.text = LevelManager.Rounds.ToString();
            Debug.Log("rounds survived: " + LevelManager.Rounds);
        }
    }
    public void LoadData(GameData data)
    {
        LevelManager.Rounds = data.roundCount;
    }

    public void SaveData(ref GameData data)
    {
        data.roundCount = LevelManager.Rounds;
    }
}
