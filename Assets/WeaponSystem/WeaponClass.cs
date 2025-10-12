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

	public void InstantiateWeaponModel(string handType)
	{
		if (weaponModel != null)
		{
			currentModelInstance = Instantiate(weaponModel);
			weaponMeshRenderer = currentModelInstance.GetComponent<MeshRenderer>();
			currentModelInstance.transform.parent = transform;
			if (handType == "left")
			{
				currentModelInstance.transform.localPosition = new Vector3(-0.35f, 1.75f, 0.5f); // ��������� ������� ��� ����� ����
			}
			else if(handType == "right")
			{
				currentModelInstance.transform.localPosition = new Vector3(0.35f, 1.75f, 0.5f); // ��������� ������� ��� ������ ����
			}
			currentModelInstance.transform.localRotation = Quaternion.Euler(0, 0, 0); // ��������� ��������
		}
	}

	public void DestroyWeaponModel()
	{
		if (currentModelInstance != null)
		{
			Destroy(currentModelInstance);
			currentModelInstance = null;
		}
	}
}