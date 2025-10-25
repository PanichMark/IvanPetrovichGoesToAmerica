using UnityEngine;

public class VendingMachineDoctorPoppels : VendingMachineAbstract
{

	public GameObject ManaReplenishItemModel;


	public override string ItemName => "�������� �� ������� ������";

	public override string GoodsName => "�����";

	private int goodsPrice = 15;

	private void Awake()
	{
		ManaReplenishItemModel = Resources.Load<GameObject>("ManaReplenishItem"); // ��������� ������ ����������

	}
	public override void Interact()
	{
		if (PlayerMoneyManager.Instance.PlayerMoney >= goodsPrice)
		{
			Vector3 spawnPosition = transform.position + new Vector3(-1f, 0.5f, 0f); // �������� ������ ����� �� �������

			Debug.Log($"�� ������ {GoodsName} � {ItemName}");
			Instantiate(ManaReplenishItemModel, spawnPosition, Quaternion.identity);
			PlayerMoneyManager.Instance.DeductMoney(-goodsPrice);
		}
		else Debug.Log("Not enought Money");
	}
}