using UnityEngine;

public class LootItemCoin5 : LootItem
{
	public override int MoneyValue { get; protected set; } = 5;

	public override string ItemName => "������ 5 ������";


	public override void Interact()
	{
		Debug.Log($"�� ������� {ItemName}, ��������� {MoneyValue} ������");
		Destroy(gameObject);
		PlayerMoneyManager.Instance.AddMoney(MoneyValue);
	}
	// ���� ����� �� ��������� � ��������������� InteractionHint,
	// ��� ��� ������� ���������� ������ ��������
}