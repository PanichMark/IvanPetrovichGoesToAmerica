using UnityEngine;

public class WeaponHarmonicaRevolver : WeaponClass
{
    WeaponHarmonicaRevolver()
    {
        WeaponName = "HarmonicaRevolver";
	}

	public void Awake()
	{
		weaponModel = Resources.Load<GameObject>("WeaponHarmonicaRevolver"); // ��������� ������ ����������
		Debug.Log("�������� ������: " + weaponModel);
	}

}
