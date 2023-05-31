using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistenceManager> dataPersistenceManagers;

    public FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        instance = this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceManagers = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private List<IDataPersistenceManager> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistenceManager> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistenceManager>();
        return new List<IDataPersistenceManager>(dataPersistenceObjects);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data was found.");
            NewGame();
        }

        foreach (IDataPersistenceManager dataPersistenceObj in dataPersistenceManagers)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Load Round Count = " + gameData.roundCount);
    }
    public void SaveGame()
    {
        foreach (IDataPersistenceManager dataPersistenceObj in dataPersistenceManagers)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        Debug.Log("Save Round Count = " + gameData.roundCount);
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
