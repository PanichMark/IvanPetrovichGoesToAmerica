using UnityEngine;

public class VendingMachineDoctorPoppels : VendingMachineAbstract
{
	//public override int MoneyValue { get; protected set; } = 5;

	public override string ItemName => "�������� �� ������� ������";

	public override string GoodsName => "�����";


	public override void Interact()
	{
		Debug.Log($"�� ������ {GoodsName} � {ItemName}");
		//	Destroy(gameObject);
		//PlayerMoneyManager.Instance.AddMoney(MoneyValue);
	}
}