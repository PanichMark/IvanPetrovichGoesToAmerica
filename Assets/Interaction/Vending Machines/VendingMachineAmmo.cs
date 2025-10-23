using UnityEngine;

public class VendingMachineAmmo : VendingMachineAbstract
{

	public GameObject HealingItemModel;


	public override string ItemName => "�������� �� ������� ��������";

	public override string GoodsName => "�������";

	private int goodsPrice = 30;

	private void Awake()
	{
		HealingItemModel = Resources.Load<GameObject>("HealingItem"); // ��������� ������ ����������

	}
	public override void Interact()
	{
		if (PlayerMoneyManager.Instance.PlayerMoney >= goodsPrice)
		{
			Vector3 spawnPosition = transform.position + new Vector3(-1f, 0.5f, 0f); // �������� ������ ����� �� �������

			Debug.Log($"�� ������ {GoodsName} � {ItemName}");
			Instantiate(HealingItemModel, spawnPosition, Quaternion.identity); 
			PlayerMoneyManager.Instance.DeductMoney(-goodsPrice);
		}
		else Debug.Log("Not enought Money");
	}
}