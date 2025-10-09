using UnityEngine;

public class WeaponPoliceBaton : WeaponClass
{
    public WeaponPoliceBaton()
    {
        WeaponName = "PoliceBaton";
		//weaponModel = Resources.Load<GameObject>("Prefabs/PoliceBaton"); // ��������� ������ �������
	}

	public void Awake()
	{
		weaponModel = Resources.Load<GameObject>("WeaponPoliceBaton"); // ��������� ������ ����������
		//Debug.Log("�������� ������: " + weaponModel);
	}

	public override void WeaponAttack()
	{
		Debug.Log("PoliceBatonAttack");
	}
}
