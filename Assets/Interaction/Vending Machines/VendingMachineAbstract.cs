using UnityEngine;

public abstract class VendingMachineAbstract : MonoBehaviour, IInteractable
{

	public virtual string InteractionItemName => gameObject.name;
	public virtual string InteractionHint => $"������ {GoodsName} � {InteractionItemName}?";
	public virtual string GoodsName => gameObject.name;



	public abstract void Interact();
}
	