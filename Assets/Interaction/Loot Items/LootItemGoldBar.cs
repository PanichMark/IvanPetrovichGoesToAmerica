using UnityEngine;

public class LootItemGoldBar : LootItemAbstract
{
	public override int MoneyValue { get; protected set; } = 20;

	public override string ItemName => "������� ������";


	public override void Interact()
	{
		Debug.Log($"�� ������� {ItemName}, ��������� {MoneyValue} ������");
		Destroy(gameObject);
		PlayerMoneyManager.Instance.AddMoney(MoneyValue);
	}
}