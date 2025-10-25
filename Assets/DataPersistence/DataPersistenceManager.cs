using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
	[SerializeField] private string fileSaveDataName1 = "";
	[SerializeField] private string fileSaveDataName2 = "";
	[SerializeField] private string fileSaveDataName3 = "";
	[SerializeField] private string fileSaveDataName4 = "";
	[SerializeField] private string fileSaveDataName5 = "";

	//private string saveElsewhere = @"C:\Users\PanichMark\Desktop";

	private GameData gameData;
	private List<IDataPersistence> dataPersistenceObjects;
	private FileDataHandler fileDataHandler;
	[SerializeField] private int WhatSaveNumberWasLoaded;

    public static DataPersistenceManager Instance {  get; private set; }




	private void Awake()
	{


		// ������� Singleton: ������������� �������� ������� ����������
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); // ����������� ��� ����� �������
		}
		else
		{
			Destroy(gameObject); // ���������� ������ ����������
		}

		fileSaveDataName1 = "SAVEGAME1.json";
		fileSaveDataName2 = "SAVEGAME2.json";
		fileSaveDataName3 = "SAVEGAME3.json";
		fileSaveDataName4 = "SAVEGAME4.json";
		fileSaveDataName5 = "SAVEGAME5.json";





		//this.DataHandler = new FileDataHandler(saveElsewhere, fileName);
		//this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName1);
		this.dataPersistenceObjects = FindAllDataPersistenceObjects();

		Debug.Log(WhatSaveNumberWasLoaded);

		if (WhatSaveNumberWasLoaded >= 1 && WhatSaveNumberWasLoaded <= 5)
		{
			string fileSaveDataName = null;
			if (WhatSaveNumberWasLoaded == 1)
			{
				fileSaveDataName = fileSaveDataName1;
			}
			else if (WhatSaveNumberWasLoaded == 2)
			{
				fileSaveDataName = fileSaveDataName2;
			}
			else if (WhatSaveNumberWasLoaded == 3)
			{
				fileSaveDataName = fileSaveDataName3;
			}
			else if (WhatSaveNumberWasLoaded == 4)
			{
				fileSaveDataName = fileSaveDataName4;
			}
			else if (WhatSaveNumberWasLoaded == 5)
			{
				fileSaveDataName = fileSaveDataName5;
			}
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName);
			this.gameData = fileDataHandler.Load();
			Debug.Log("1 < x < 5");
		}
		Debug.Log(WhatSaveNumberWasLoaded);



		Debug.Log(gameData);

		if (this.gameData == null)
		{
			Debug.Log("No data found. starting New game");
			NewGame();
		}


		Debug.Log(gameData);



		LootItemGoldBar[] goldBars = FindObjectsOfType<LootItemGoldBar>();
		for (int i = 0; i < goldBars.Length; i++)
		{
			goldBars[i].AssignLootItemIndex(i);
		}


	}


	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{

	}

	void Start()
	{
		if (this.gameData != null)
		{
			foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
			{
				dataPersistenceObj.LoadData(gameData);
			}
			Debug.Log("Data loaded from slot " + WhatSaveNumberWasLoaded);
		}
	}


	private void Update()
	{

	}

	public void NewGame()
	{
		this.gameData = new GameData();
	}

	public void SaveGame(int saveSlotNumber)
	{
        if (saveSlotNumber == 1)
        {
             this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName1);
        }
		else if (saveSlotNumber == 2)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName2);
		}
		else if (saveSlotNumber == 3)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName3);
		}
		else if (saveSlotNumber == 4)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName4);
		}
		else if (saveSlotNumber == 5)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName5);
		}

		foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
		{
			dataPersistenceObj.SaveData(ref gameData);
		}

		fileDataHandler.Save(gameData);

		Debug.Log("Data saved to slot " + saveSlotNumber);
	}

	public void LoadGame(int loadSlotNumber)
	{
		if (loadSlotNumber == 1)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName1);
			WhatSaveNumberWasLoaded = 1;
		}
		else if (loadSlotNumber == 2)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName2);
			WhatSaveNumberWasLoaded = 2;
		}
		else if (loadSlotNumber == 3)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName3);
			WhatSaveNumberWasLoaded = 3;
		}
		else if (loadSlotNumber == 4)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName4);
			WhatSaveNumberWasLoaded = 4;
		}
		else if (loadSlotNumber == 5)
		{
			this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileSaveDataName5);
			WhatSaveNumberWasLoaded = 5;
		}

		Debug.Log(gameData);
		this.gameData = fileDataHandler.Load();
		Debug.Log("Gamedata was = file");
		Debug.Log(gameData);
		Debug.Log(WhatSaveNumberWasLoaded);

		if (this.gameData == null)
		{
			Debug.Log("No data to load found in slot " + loadSlotNumber);
			WhatSaveNumberWasLoaded = 0;
			Debug.Log(WhatSaveNumberWasLoaded);

			return;
		}
		else
		{
			string sceneName = SceneManager.GetActiveScene().name;

			SceneManager.LoadScene(sceneName);
			Debug.Log($"Scene {sceneName} reloaded");
		}
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

		return new List<IDataPersistence>(dataPersistenceObjects);
	}
}
