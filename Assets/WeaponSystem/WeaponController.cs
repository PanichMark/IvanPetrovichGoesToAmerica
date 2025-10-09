using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
	public Button PoliceBatonButton;
	public Button HarmonicaRevolverButton;
	public Button PlungerCrossbowButton;
	public Button EugenicGenieButton;

	PlayerInputsList playerInputsList;

	private WeaponClass leftHandWeapon;
	private WeaponClass rightHandWeapon;

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
	}

	private void Update()
	{
		/*
		if (leftHandWeapon != null && rightHandWeapon != null && rightHandWeapon.WeaponName == leftHandWeapon.WeaponName)
		{
			Debug.Log("���������");
		}
		*/

		if (playerInputsList.GetKeyRightHandWeaponAttack())
		{
			RightWeaponAttack();
		}

		if (playerInputsList.GetKeyLeftHandWeaponAttack())
		{
			LeftWeaponAttack();
		}
	}

	private void SelectWeapon(System.Type weaponType)
	{
		bool isLeftHand = weaponWheelController.IsWeaponLeftHand;

		// ���������, ���� �� ������ � ����� ����
		if (weaponWheelController.IsWeaponLeftHand && leftHandWeapon != null && leftHandWeapon.GetType() == weaponType)
		{
			// ���� ������� ������ ��������� � ���������, ������ �� ������
			return;
		}
		// ���������, ���� �� ������ � ������ ����
		else if (!isLeftHand && rightHandWeapon != null && rightHandWeapon.GetType() == weaponType)
		{
			// ���� ������� ������ ��������� � ���������, ������ �� ������
			return;
		}
		else
		{
			

			// ���� ������ �� ������� �� � ����� ����, ������� ����� ��������� ������
			if (isLeftHand)
			{
			

				if (leftHandWeapon != null)
				{
					leftHandWeapon.Unequip(); // ��������� ����� Unequip()
					Destroy(leftHandWeapon); // ���������� ���������� ������
					leftHandWeapon = null;
				}
				else if (rightHandWeapon != null && rightHandWeapon.GetType() == weaponType)
				{
					rightHandWeapon.Unequip(); // ��������� ����� Unequip()
					Destroy(rightHandWeapon); // ���������� ���������� ������
					rightHandWeapon = null;
				}

				

					// ������� ����� ��������� ������
					leftHandWeapon = (WeaponClass)gameObject.AddComponent(weaponType);
				leftHandWeapon.Equip(true); // �������� ���� isLeftHand
			}
			else
			{
				if (rightHandWeapon != null)
				{
					rightHandWeapon.Unequip(); // ��������� ����� Unequip()
					Destroy(rightHandWeapon); // ���������� ���������� ������
					rightHandWeapon= null;
				}
				else if (leftHandWeapon != null && leftHandWeapon.GetType() == weaponType)
				{
					leftHandWeapon.Unequip(); // ��������� ����� Unequip()
					Destroy(leftHandWeapon); // ���������� ���������� ������
					leftHandWeapon= null;
				}

				

				// ������� ����� ��������� ������
				rightHandWeapon = (WeaponClass)gameObject.AddComponent(weaponType);
				rightHandWeapon.Equip(false); // �������� ���� isLeftHand




				

				
			}

				 if ( leftHandWeapon != null && rightHandWeapon != null && rightHandWeapon.WeaponName == leftHandWeapon.WeaponName)
				{
					if (isLeftHand == true)
					{
						rightHandWeapon.Unequip(); // ��������� ����� Unequip()
						Destroy(rightHandWeapon); // ���������� ���������� ������
					rightHandWeapon = null;
					}
					else if (isLeftHand == false)
					{
						leftHandWeapon.Unequip(); // ��������� ����� Unequip()
						Destroy(leftHandWeapon); // ���������� ���������� ������
					leftHandWeapon = null;
					}
				}

			Debug.Log("LeftHand: " + (leftHandWeapon?.WeaponName ?? "null") + " | RightHand: " + (rightHandWeapon?.WeaponName ?? "null"));
		}
	}


	public void RightWeaponAttack()
	{
		if (rightHandWeapon != null)
		{
			rightHandWeapon.WeaponAttack();
		}
	}

	public void LeftWeaponAttack()
	{
		if (leftHandWeapon != null)
		{
			leftHandWeapon.WeaponAttack();
		}
	}

}