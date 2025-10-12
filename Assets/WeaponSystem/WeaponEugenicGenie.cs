using UnityEngine;

public class WeaponEugenicGenie : WeaponClass
{
    WeaponEugenicGenie()
    {
        WeaponNameSystem = "EugenicGenie";
		WeaponNameUI = "������� ������� ������";
	}

	public void Awake()
	{
		weaponModel = Resources.Load<GameObject>("WeaponEugenicsGenie"); // ��������� ������ ����������
	}

	public override void WeaponAttack()
	{
		Debug.Log("EugenicAttack");
	}
}
