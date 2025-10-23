using UnityEngine;

public class LootItemGoldBar : LootItemAbstract
{
	public override int MoneyValue { get; protected set; } = 20;

	public override string ItemName => "������� ������";

	private GameObject NewInstance;

	private void Start()
	{
		LootItemPosition = transform.position;
		LootItemRotation = transform.rotation;
	}

	public override void Interact()
	{
		

		Debug.Log($"�� ������� {ItemName}, ��������� {MoneyValue} ������");
		Destroy(gameObject);
		PlayerMoneyManager.Instance.AddMoney(MoneyValue);
		WasLootItemCollected = true;
		
	}

	private void Update()
	{
		//Debug.Log(gameObject);
		Debug.Log(CollectableIndex);
		//Debug.Log(LootItemPosition);
	}

	public override void LoadData(GameData data)
	{


		if (data.WasLootItemCollectedGoldBar[CollectableIndex] == false && WasLootItemCollected == true)
		{
			
			//Instantiate(Resources.Load<GameObject>("GoldBar"), LootItemPosition, LootItemRotation);
			NewInstance = Instantiate(Resources.Load<GameObject>("GoldBar"), LootItemPosition, LootItemRotation);

			WasLootItemCollected = false;
			Debug.Log("LOADED");
		}

		if (data.WasLootItemCollectedGoldBar[CollectableIndex] == true)
		{
			if (WasLootItemCollected == false)
			{
				if (NewInstance == null)
				{
					Destroy(gameObject); // ���� ������� ������, ������� ���
				}
				else if (NewInstance != null) 
				{
					Destroy(NewInstance);
				}
			}
			WasLootItemCollected = true;
		}
		DataPersistenceManager.instance.ReAssignLootItemIndexes();

	}

	public override void SaveData(ref GameData data)
	{
		// ��������� ���� ����� ��������
		if (WasLootItemCollected == true)
		{
			data.WasLootItemCollectedGoldBar[CollectableIndex] = true;
		}
	}
}