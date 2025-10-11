using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
	public Button PoliceBatonButton;
	public Button HarmonicaRevolverButton;
	public Button PlungerCrossbowButton;
	public Button EugenicGenieButton;

	PlayerInputsList playerInputsList;
	PlayerBehaviour playerBehaviour;

	public WeaponClass LeftHandWeapon {  get; private set; }
	public WeaponClass RightHandWeapon {  get; private set; }

	WeaponWheelController weaponWheelController;

	private void Start()
	{
		//leftHandWeapon = GetComponent<WeaponClass>();
		//rightHandWeapon = GetComponent<WeaponClass>();
		playerInputsList = GetComponent<PlayerInputsList>();

		weaponWheelController = GetComponent<WeaponWheelController>();

		// ��������� ����������� ������� ��� ������
		PoliceBatonButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponPoliceBaton)));
		HarmonicaRevolverButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponHarmonicaRevolver)));
		PlungerCrossbowButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponPlungerCrossbow)));
		EugenicGenieButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponEugenicGenie)));

		playerBehaviour = GetComponent<PlayerBehaviour>();
	}

	private void Update()
	{
		/*
		if (leftHandWeapon != null && rightHandWeapon != null && rightHandWeapon.WeaponName == leftHandWeapon.WeaponName)
		{
			Debug.Log("���������");
		}
		*/

		if (playerInputsList.GetKeyRightHandWeaponAttack() && !GameManager.IsAnyMenuOpened)
		{
			RightWeaponAttack();
		}

		if (playerInputsList.GetKeyLeftHandWeaponAttack() && !GameManager.IsAnyMenuOpened)
		{
			LeftWeaponAttack();
		}
	}

	private void SelectWeapon(System.Type weaponType)
	{
		bool isLeftHand = weaponWheelController.IsWeaponLeftHand;

		// ���������, ���� �� ������ � ����� ����
		if (weaponWheelController.IsWeaponLeftHand && LeftHandWeapon != null && LeftHandWeapon.GetType() == weaponType)
		{
			// ���� ������� ������ ��������� � ���������, ������ �� ������
			return;
		}
		// ���������, ���� �� ������ � ������ ����
		else if (!isLeftHand && RightHandWeapon != null && RightHandWeapon.GetType() == weaponType)
		{
			// ���� ������� ������ ��������� � ���������, ������ �� ������
			return;
		}
		else
		{


			// ���� ������ �� ������� �� � ����� ����, ������� ����� ��������� ������
			if (isLeftHand)
			{


				if (LeftHandWeapon != null)
				{
					//leftHandWeapon.Unequip(); // ��������� ����� Unequip()
					//Destroy(leftHandWeapon); // ���������� ���������� ������
					//leftHandWeapon = null;
					RemoveLeftWeapon();
				}
				else if (RightHandWeapon != null && RightHandWeapon.GetType() == weaponType)
				{
					//rightHandWeapon.Unequip(); // ��������� ����� Unequip()
					//Destroy(rightHandWeapon); // ���������� ���������� ������
					//rightHandWeapon = null;
					RemoveRightWeapon();
				}



				// ������� ����� ��������� ������
				LeftHandWeapon = (WeaponClass)gameObject.AddComponent(weaponType);
				LeftHandWeapon.Equip(true); // �������� ���� isLeftHand
				playerBehaviour.ArmPlayer();
			}
			else
			{
				if (RightHandWeapon != null)
				{
					//rightHandWeapon.Unequip(); // ��������� ����� Unequip()
					//Destroy(rightHandWeapon); // ���������� ���������� ������
					//rightHandWeapon = null;
					RemoveRightWeapon();
				}
				else if (LeftHandWeapon != null && LeftHandWeapon.GetType() == weaponType)
				{
					//leftHandWeapon.Unequip(); // ��������� ����� Unequip()
					//Destroy(leftHandWeapon); // ���������� ���������� ������
					//leftHandWeapon = null;
					RemoveLeftWeapon();
				}



				// ������� ����� ��������� ������
				RightHandWeapon = (WeaponClass)gameObject.AddComponent(weaponType);
				RightHandWeapon.Equip(false); // �������� ���� isLeftHand
				playerBehaviour.ArmPlayer();







			}

			if (LeftHandWeapon != null && RightHandWeapon != null && RightHandWeapon.WeaponName == LeftHandWeapon.WeaponName)
			{
				if (isLeftHand == true)
				{
					//rightHandWeapon.Unequip(); // ��������� ����� Unequip()
					//Destroy(rightHandWeapon); // ���������� ���������� ������
					//rightHandWeapon = null;
					RemoveRightWeapon();
				}
				else if (isLeftHand == false)
				{
					//leftHandWeapon.Unequip(); // ��������� ����� Unequip()
					//Destroy(leftHandWeapon); // ���������� ���������� ������
					//leftHandWeapon = null;
					RemoveLeftWeapon();
				}
			}

			Debug.Log("LeftHand: " + (LeftHandWeapon?.WeaponName ?? "null") + " | RightHand: " + (RightHandWeapon?.WeaponName ?? "null"));
		}
	}


	public void RightWeaponAttack()
	{
		if (RightHandWeapon != null)
		{
			RightHandWeapon.WeaponAttack();
		}
	}

	public void LeftWeaponAttack()
	{
		if (LeftHandWeapon != null)
		{
			LeftHandWeapon.WeaponAttack();
		}
	}
	public void RemoveRightWeapon()
	{
		RightHandWeapon.Unequip(); // ��������� ����� Unequip()
		Destroy(RightHandWeapon); // ���������� ���������� ������
		RightHandWeapon = null;
	}

	public void RemoveLeftWeapon()
	{
		LeftHandWeapon.Unequip(); // ��������� ����� Unequip()
		Destroy(LeftHandWeapon); // ���������� ���������� ������
		LeftHandWeapon = null;
	}

	public void ShowRightWeapon()
	{
		RightHandWeapon.weaponMeshRenderer.enabled = true;
	}

	public void ShowLeftWeapon()
	{
		LeftHandWeapon.weaponMeshRenderer.enabled = true;
	}
	public void HideRightWeapon()
	{
		RightHandWeapon.weaponMeshRenderer.enabled = false;
	}

	public void HideLeftWeapon()
	{
		LeftHandWeapon.weaponMeshRenderer.enabled = false;
	}
}