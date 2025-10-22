using UnityEngine;

public abstract class LootItem : MonoBehaviour, IInteractable
{
	public string ItemName;              // �������� ��������
	public int MoneyValue;               // �������� ���������
	public string InteractionHint => $"������� {ItemName}?";

	public abstract void Interact();     // ������������ ����� ��������������
}
