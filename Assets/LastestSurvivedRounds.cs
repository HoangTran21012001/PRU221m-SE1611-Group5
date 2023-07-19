using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LastestSurvivedRounds : MonoBehaviour
{
    public Text roundsSurviedText;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        LoadData();
    }
    private void LoadData() {
        string fullPath = Application.persistentDataPath + "/data.json";
        string json = File.ReadAllText(fullPath);
        GameData data = JsonUtility.FromJson<GameData>(json);
    }
}
