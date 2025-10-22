using UnityEngine;

public abstract class LootItem : MonoBehaviour, IInteractable
{
	public virtual string ItemName => gameObject.name;

	public virtual string InteractionHint => $"������� {ItemName}";

	public virtual int MoneyValue { get; protected set; }
	public abstract void Interact();
}