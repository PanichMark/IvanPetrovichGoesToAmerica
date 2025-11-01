using UnityEngine;

public class LootItemCoin2 : LootItemAbstract
{
	public override int MoneyValue { get; protected set; } = 2;

	public override string InteractionItemName => "������ 2 �����";


	public override void Interact()
	{
		Debug.Log($"�� ������� {InteractionItemName}, ��������� {MoneyValue} ������");
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