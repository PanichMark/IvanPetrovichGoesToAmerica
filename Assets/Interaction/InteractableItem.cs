using UnityEngine;

public abstract class InteractableItem : MonoBehaviour, IInteractable
{
	public virtual string ItemName => gameObject.name;

	public virtual string InteractionHint => $"{ItemName}: ������������� ���������"; // ��������� ������

	public abstract void Interact();
}