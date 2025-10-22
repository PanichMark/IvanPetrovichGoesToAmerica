using UnityEngine;

public abstract class VendingMachineItem : InteractableItem
{
	public abstract string GoodsName { get; protected set; }

	public override string InteractionHint => $"������ {GoodsName} � {ItemName}?";

	public sealed override void Interact()
	{
		Debug.Log($"�� ������ {GoodsName} � {ItemName}");
	//	Destroy(gameObject);
		//PlayerMoneyManager.Instance.AddMoney(MoneyValue);
	}
}