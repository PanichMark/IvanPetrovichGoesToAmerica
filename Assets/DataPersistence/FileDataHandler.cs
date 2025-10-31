﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;

public class FileDataHandler
{

	private string dataDirPAth = "";

	private string dataFileName = "";

	public FileDataHandler(string dataDirPath, string dataFileName)
	{
		this.dataDirPAth = dataDirPath;
		this.dataFileName = dataFileName;
	}

	public GameData Load()
	{
		string fullPath = Path.Combine(dataDirPAth, dataFileName);
		GameData loadedData = null;
		if (File.Exists(fullPath))
		{
			try
			{
				string dataToLoad = "";
				using (FileStream stream = new FileStream(fullPath, FileMode.Open))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						dataToLoad = reader.ReadToEnd();
					}
				}
				loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

			}
			catch (Exception e) 
			{
				Debug.LogError("Loading error: " + fullPath + "/n" + e);
			}
		}
		return loadedData;
	}

	public void Save(GameData data)
	{
		string fullPath = Path.Combine(dataDirPAth, dataFileName);
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			string dataToStore = JsonUtility.ToJson(data, true);

			using (FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					writer.Write(dataToStore);
				}
			}
		}
		catch (Exception e)
		{
			Debug.LogError("Saving error: " + fullPath + "/n" + e);
		}
	}
}
