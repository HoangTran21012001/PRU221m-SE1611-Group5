using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;
    public static int Lives;
    public int startLives = 20;
    public static int Rounds;
    public int currency;

    private void Awake()
    {
        main = this;
        Lives = startLives;
        Rounds = 0;
    }

    private void Start()
    {
        currency = 100;
    }

    public void InCreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
}
