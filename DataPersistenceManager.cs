using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using teamFourFinalProject;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

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
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();

        if (KeyManager.instance != null)
        {
            KeyManager.instance.ResetKeys();
        }

        SaveGame();
    }

    public void LoadGame()
    {
        //Load saved data from a file using the data handler
        this.gameData = dataHandler.Load();

        //If no data can be loaded, initialize new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initialzing data to defaults");
            NewGame();
        }

        //Push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Loaded current health = " + gameData.curHealth);
    }

    public void SaveGame()
    {
        //Pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved current health = " + gameData.curHealth);

        //Save that data to a file using the data handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void DeleteSavedGame()
    {
        dataHandler.DeleteSaveFile();
    }
}
