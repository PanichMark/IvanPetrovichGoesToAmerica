﻿using UnityEngine;


[System.Serializable]



public class GameData
{
	//CurrentScene
	public string CurrentScene;

	//Player Movement
	public string CurrentPlayerMovementStateType;
	public Vector3 PlayerPosition;
	public Quaternion PlayerRotation;


	//Camera
	public string CurrentPlayerCameraStateType;
	public float PlayerCameraDistanceY;
	public float PlayerCameraDistanceZ;
	public Quaternion CameraRotation;
	public bool IsCameraShoulderRight;

	//PlayerMoney
	public int PlayerMoney;

	//PlayerHealth
	public int PlayerHealth;
	public int HealingItems;

	//PlayerMana
	public int PlayerMana;
	public int ManaReplenishItems;

	//Collectables
	public LootItemData[] LootItemSceneTESTDataGoldBar;
	public LootItemData[] LootItemScene1DataGoldBar;



	public GameData()
	{
		CurrentScene = "SceneTEST";

		CurrentPlayerMovementStateType = "PlayerIdle";
		PlayerPosition = new Vector3(2, 0, 4);
		PlayerRotation = new Quaternion(0, 0, 0, 0);

		CurrentPlayerCameraStateType = "ThirdPerson";
		PlayerCameraDistanceY = -1.75f;
		PlayerCameraDistanceZ = 3.25f;
		CameraRotation = new Quaternion(0, 0, 0, 0);
		IsCameraShoulderRight = true;

		PlayerMoney = 200;

		PlayerHealth = 40;
		HealingItems = 3;

		PlayerMana = 15;
		ManaReplenishItems = 6;

		LootItemSceneTESTDataGoldBar = new LootItemData[10];
		LootItemScene1DataGoldBar = new LootItemData[10];

	}



}

[System.Serializable]
public struct LootItemData
	{
		public int LootItemIndex;        // Целое число
		public bool WasLootItemCollected;      // Булевое значение
		//public Vector3 LootItemPosition;   // Трёхмерный вектор
		//public Quaternion LootItemRotation; // Кватернион
	}
