using UnityEngine;

public class LootItemGoldBar : LootItemAbstract
{
	public override int MoneyValue { get; protected set; } = 20;

	public override string InteractionItemName => "������� ������";

	//private GameObject NewInstance;

	public override void Interact()
	{
		

		Debug.Log($"�� ������� {InteractionItemName}, ��������� {MoneyValue} ������");
		Destroy(gameObject);
		PlayerMoneyManager.Instance.AddMoney(MoneyValue);
		WasLootItemCollected = true;
		
	}

	private void Update()
	{
		//Debug.Log(gameObject);
		//Debug.Log(LootItemIndex);
		//Debug.Log(LootItemPosition);
	}

	public override void SaveData(ref GameData data)
	{
		if (WasLootItemCollected == true)
		{
			data.LootItemDataGoldBar[LootItemIndex].WasLootItemCollected = true;
		}
		else data.LootItemDataGoldBar[LootItemIndex].WasLootItemCollected = false;

		//data.LootItemDataGoldBar[LootItemIndex].LootItemPosition = transform.position;
		//data.LootItemDataGoldBar[LootItemIndex].LootItemRotation = transform.rotation;

		data.LootItemDataGoldBar[LootItemIndex].LootItemIndex = LootItemIndex;
	}

	public override void LoadData(GameData data)
	{
		if (data.LootItemDataGoldBar[LootItemIndex].WasLootItemCollected == true)
		{
			WasLootItemCollected = true;
			Destroy(gameObject); // ���� ������� ������, ������� ���
		}

		/*
		if (data.LootItemDataGoldBar[LootItemIndex].WasLootItemCollected == true && WasLootItemCollected == false)
		{
			if (NewInstance == null)
			{
				Destroy(gameObject); // ���� ������� ������, ������� ���
			}
			else
			{
				Destroy(NewInstance);
			}

			WasLootItemCollected= true;
		}
		
		else if (data.LootItemDataGoldBar[LootItemIndex].WasLootItemCollected == false && WasLootItemCollected == true)
		{
			LootItemIndex = data.LootItemDataGoldBar[LootItemIndex].LootItemIndex;

			NewInstance = Instantiate(Resources.Load<GameObject>("GoldBar"), data.LootItemDataGoldBar[LootItemIndex].LootItemPosition,
			data.LootItemDataGoldBar[LootItemIndex].LootItemRotation);

			WasLootItemCollected = false;
		}
		*/


	}


}