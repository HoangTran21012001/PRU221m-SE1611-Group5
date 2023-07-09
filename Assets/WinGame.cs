using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour,IDataPersistenceManager
{
    // Start is called before the first frame update
    [SerializeField] GameObject starPointSecond;
    [SerializeField] GameObject starPointThird;
    public static int starRate;
    public void LoadData(GameData data)
    {
        starRate = data.pointRate;
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log(starRate);
        data.pointRate = starRate;
    }

    private void OnEnable()
    {
        if (LevelManager.startLives >= 20)
        {
            starPointSecond.SetActive(true);
            starPointThird.SetActive(true);
            starRate = 3;
            
        }
        else if(LevelManager.startLives >= 15)
        {
            starPointSecond.SetActive(true);
            starRate = 2;
        }
        else
        {
            starRate = 1;
        }
    }

}
