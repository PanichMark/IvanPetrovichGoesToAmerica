using UnityEngine;
using System;
using Unity.IO.LowLevel.Unsafe;

public abstract class LootItemAbstract : MonoBehaviour, IInteractable, IDataPersistence
{
	//public virtual Vector3 LootItemPosition { get; protected set; }
	//public virtual Quaternion LootItemRotation { get; protected set; }
	public virtual string InteractionItemName => gameObject.name;

	public virtual string InteractionHint => $"������� {InteractionItemName}";

	public virtual int MoneyValue { get; protected set; }

	public virtual bool WasLootItemCollected { get; protected set; }
	

	// ���� ��� ����������� ������� � �������� ���� ��������
	public int LootItemIndex { get; protected set; }
	//public Type CollectableType { get; private set; }

	// ������������� ��������� ���������� �������

	/*
	internal void AssignLootItemIndex(int index, Type type)
	{
		CollectableIndex = index;
		CollectableType = type;
	}
	*/
	internal void AssignLootItemIndex(int index)
	{
		LootItemIndex = index;
	}

	public abstract void Interact();

	public abstract void LoadData(GameData data);


	public abstract void SaveData(ref GameData data);

}