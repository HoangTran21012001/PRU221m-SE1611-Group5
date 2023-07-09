using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int roundCount;
    public int pointRate;

    public GameData()
    {
        this.roundCount = 0;
        this.pointRate = 0;
    }
}
