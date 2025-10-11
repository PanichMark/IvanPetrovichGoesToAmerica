using UnityEngine;

public class WeaponPlungerCrossbow : WeaponClass
{
    public WeaponPlungerCrossbow()
    {
        WeaponName = "PlungerCrossbow";
    }

	public void Awake()
	{
		weaponModel = Resources.Load<GameObject>("WeaponPlungerCrossbow"); // ��������� ������ ����������
	//	weaponMeshRenderer = weapon
		//Debug.Log("�������� ������: " + weaponModel);
	}

	public override void WeaponAttack()
	{
		Debug.Log("CrossbowAttack");
	}
}
