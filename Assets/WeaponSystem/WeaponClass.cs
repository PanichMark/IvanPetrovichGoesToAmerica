using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
	public string WeaponNameSystem;
	public string WeaponNameUI;
	public float WeaponDamage;
	public GameObject weaponModel; // ������ �� 3D ������ ������
	public GameObject currentModelInstance; // ������ �� ���������������� ������
	public MeshRenderer weaponMeshRenderer;

	public virtual void WeaponAttack()
	{
		// 4 weapon classes override this method
	}

	public virtual void Equip(bool isLeftHand)
	{
		string hand = isLeftHand ? "Left Hand" : "RightHand";
		//Debug.Log(WeaponName + " Equiped in " + hand);
		InstantiateWeaponModel(isLeftHand);
	}

	public virtual void Unequip()
	{
		//Debug.Log(WeaponName + " Unequiped");
		DestroyWeaponModel();
	}

	protected void InstantiateWeaponModel(bool isLeftHand)
	{
		if (weaponModel != null)
		{
			currentModelInstance = Instantiate(weaponModel);
			weaponMeshRenderer = currentModelInstance.GetComponent<MeshRenderer>();
			currentModelInstance.transform.parent = transform;
			if (isLeftHand)
			{
				currentModelInstance.transform.localPosition = new Vector3(-0.35f, 1.75f, 0.5f); // ��������� ������� ��� ����� ����
			}
			else
			{
				currentModelInstance.transform.localPosition = new Vector3(0.35f, 1.75f, 0.5f); // ��������� ������� ��� ������ ����
			}
			currentModelInstance.transform.localRotation = Quaternion.Euler(0, 0, 0); // ��������� ��������
		}
	}

	protected void DestroyWeaponModel()
	{
		if (currentModelInstance != null)
		{
			Destroy(currentModelInstance);
			currentModelInstance = null;
		}
	}
}