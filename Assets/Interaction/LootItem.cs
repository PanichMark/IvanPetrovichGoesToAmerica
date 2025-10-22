using UnityEngine;

public abstract class LootItem : InteractableItem
{
	public abstract int MoneyValue { get; protected set; }

	public override string InteractionHint => $"������� {ItemName}";

	public sealed override void Interact()
	{
		Debug.Log($"�� ������� {ItemName}, ��������� ${MoneyValue}");
		Destroy(gameObject);
		PlayerMoneyManager.Instance.AddMoney(MoneyValue);
	}
}