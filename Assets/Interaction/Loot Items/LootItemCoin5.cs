using UnityEngine;

public class LootItemCoin5 : LootItemAbstract
{
	public override int MoneyValue { get; protected set; } = 5;

	public override string ItemName => "������ 5 ������";


	public override void Interact()
	{
		Debug.Log($"�� ������� {ItemName}, ��������� {MoneyValue} ������");
		Destroy(gameObject);
		PlayerMoneyManager.Instance.AddMoney(MoneyValue);
	}

	public override void LoadData(GameData data)
	{

	}

	public override void SaveData(ref GameData data)
	{

	}
}