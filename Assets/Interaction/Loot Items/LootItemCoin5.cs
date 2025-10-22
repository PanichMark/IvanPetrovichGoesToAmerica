using UnityEngine;

public class LootItemCoin5 : LootItem
{
	void Start()
	{
		ItemName = "������ 5 ������";
		MoneyValue = 5;
}

	public override void Interact()
	{
		Debug.Log($"�� ������� {ItemName}, ��������� ${MoneyValue}");
		Destroy(gameObject);           // ������� ������
		PlayerMoneyManager.Instance.AddMoney(MoneyValue); // ��������� ������ ������
	}
}
