using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
	public Button PoliceBatonButton;
	public Button HarmonicaRevolverButton;
	public Button PlungerCrossbowButton;
	public Button EugenicGenieButon;

	private WeaponClass currentWeapon;

	private void Start()
	{
		// ��������� ����������� ������� ��� ������
		PoliceBatonButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponPoliceBaton)));
		HarmonicaRevolverButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponHarmonicaRevolver)));
		PlungerCrossbowButton.onClick.AddListener(() => SelectWeapon(typeof(WeaponPlungerCrossbow)));
		EugenicGenieButon.onClick.AddListener(() => SelectWeapon(typeof(WeaponEugenicGenie)));
	}


	private void SelectWeapon(System.Type weaponType)
	{
		if (currentWeapon != null && currentWeapon.GetType() == weaponType)
		{
			// ���� ������� ������ ��������� � ���������, ������������ ���
			currentWeapon.Unequip();
			Destroy(currentWeapon);
			currentWeapon = null;
		}
		else
		{
			if (currentWeapon != null)
			{
				currentWeapon.Unequip(); // ��������� ����� Unequip()
				Destroy(currentWeapon); // ���������� ���������� ������
			}

			// ������� ����� ��������� ������
			currentWeapon = (WeaponClass)gameObject.AddComponent(weaponType);
			currentWeapon.Equip();
		}
	}


	public void UseCurrentWeapon()
	{
		if (currentWeapon != null)
		{
			currentWeapon.WeaponAttack();
		}
	}
}