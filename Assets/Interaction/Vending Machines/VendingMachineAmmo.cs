using UnityEngine;

public class VendingMachineAmmo : LootItem
{
	void Start()
	{
		ItemName = "������� � ���������";
		MoneyValue = 2;
	}

	public override void Interact()
	{
		Debug.Log($"�� ������� {ItemName}, ��������� ${MoneyValue}");
		//Destroy(gameObject);           // ������� ������
		//PlayerMoneyManager.Instance.AddMoney(MoneyValue); // ��������� ������ ������
	}
}
