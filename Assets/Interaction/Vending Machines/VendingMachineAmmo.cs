using UnityEngine;

public class VendingMachineAmmo : VendingMachineItem
{
	//public override int MoneyValue { get; protected set; } = 5;

	public override string ItemName => "�������� �� ������� ��������";

	public override string GoodsName { get; protected set; }  = "�������";

	//public override int MoneyValue { get => throw new System.NotImplementedException(); protected set => throw new System.NotImplementedException(); }

	// ���� ����� �� ��������� � ��������������� InteractionHint,
	// ��� ��� ������� ���������� ������ ��������
}