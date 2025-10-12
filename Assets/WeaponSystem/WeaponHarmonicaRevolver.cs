using UnityEngine;

public class WeaponHarmonicaRevolver : WeaponClass
{
    WeaponHarmonicaRevolver()
    {
        WeaponNameSystem = "HarmonicaRevolver";
		WeaponNameUI = "��������� ���������";
	}

	public void Awake()
	{
		weaponModel = Resources.Load<GameObject>("WeaponHarmonicaRevolver"); // ��������� ������ ����������
		//Debug.Log("�������� ������: " + weaponModel);
	}

	public override void WeaponAttack()
	{
		Debug.Log("RevolverAttack");
	}

}
