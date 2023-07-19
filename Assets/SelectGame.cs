using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SelectGame : MonoBehaviour, IDataPersistenceManager
{
    // Start is called before the first frame update
    [SerializeField] GameObject starPointSecond;
    [SerializeField] GameObject starPointThird;
    public static int starRate;

    private void Awake()
    {
        starRate = WinGame.starRate;
        Debug.Log(starRate);
    }
    public void LoadData(GameData data)
    {

        starRate = data.pointRate;
    }

    public void SaveData(ref GameData data)
    {

        data.pointRate = starRate;
    }

    private void OnEnable()
    {
        if (LevelManager.Lives >= 20)
        {
            starPointSecond.SetActive(true);
            starPointThird.SetActive(true);
            starRate = 3;

        }
        else if (LevelManager.Lives >= 15)
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
