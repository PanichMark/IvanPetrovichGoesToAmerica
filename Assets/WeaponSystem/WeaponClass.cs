using UnityEngine;

public abstract class WeaponClass : MonoBehaviour
{
	public string WeaponNameSystem;
	public string WeaponNameUI;
	public float WeaponDamage;
	public GameObject weaponModel; // ������ �� 3D ������ ������
	public GameObject currentModelInstance; // ������ �� ���������������� ������
	public MeshRenderer weaponMeshRenderer;

	// ������ ���� ��� ��� ������� ����� ���������
	public GameObject LeftHandWeaponSlot; // ����� ���� (����� ����)
	public GameObject RightHandWeaponSlot; // ������ ���� (����� ����)


	public Transform LeftHandWeaponSlotTransform; // ����� ���� (����� ����)
	public Transform RightHandWeaponSlotTransform; // ������ ���� (����� ����)

	public virtual void WeaponAttack()
	{
		// 4 weapon classes override this method
	}

	public void Start()
	{
		/*
		Debug.Log(LeftHandWeaponSlot);
		LeftHandWeaponSlot = GameObject.Find("Slot.L");
		LeftHandWeaponSlotTransform = LeftHandWeaponSlot.transform;
		Debug.Log(LeftHandWeaponSlot);
		*/

		//LeftHandWeaponSlotTransform = GameObject.Find("Slot.L").transform;
	}

	public void InstantiateWeaponModel(string handType)
	{
		if (weaponModel != null)
		{
			currentModelInstance = Instantiate(weaponModel);
			weaponMeshRenderer = currentModelInstance.GetComponent<MeshRenderer>();
			//currentModelInstance.transform.parent = transform;
			if (handType == "left")
			{
				LeftHandWeaponSlotTransform = GameObject.Find("Slot.L").transform;
				currentModelInstance.transform.SetParent(LeftHandWeaponSlotTransform, true);
				
				//currentModelInstance.transform.localPosition = new Vector3(-0.35f, 1.75f, 0.5f); // ��������� ������� ��� ����� ����
			}
			else if(handType == "right")
			{

				LeftHandWeaponSlotTransform = GameObject.Find("Slot.R").transform;
				currentModelInstance.transform.SetParent(LeftHandWeaponSlotTransform, true);
				//currentModelInstance.transform.localPosition = new Vector3(0.35f, 1.75f, 0.5f); // ��������� ������� ��� ������ ����
			}
			// �������� ��������� ������� � ����������
			currentModelInstance.transform.localPosition = Vector3.zero;
			currentModelInstance.transform.localRotation = Quaternion.identity;
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