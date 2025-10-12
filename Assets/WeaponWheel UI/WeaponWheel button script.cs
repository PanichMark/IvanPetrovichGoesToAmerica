using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheelbuttonscript : MonoBehaviour
{
    public string WeaponWheelButtonName;
    public string AvailableWeaponName;
    public TextMeshProUGUI WeaponText;
    public Image WeaponSelected;
    public Sprite WeaponIcon;
    public Button WeaponButton;
    public WeaponController weaponController;
    public WeaponWheelController weaponWheelController;
	public PlayerInputsList PlayerInputsList;

    void Start()
    {
        WeaponButton = GetComponent<Button>();
    }

    public void HoverEnter()
    {
		WeaponText.text = AvailableWeaponName;

	}

	public void HoverExit()
	{
        if (weaponWheelController.IsWeaponLeftHand)
        {
            WeaponText.text = weaponController.LeftHandWeapon?.WeaponNameUI;
        }
        else if (weaponWheelController.IsWeaponLeftHand == false)
		{
			WeaponText.text = weaponController.RightHandWeapon?.WeaponNameUI;
		}

	}

	public void ChangeWeaponWheelButtonColorToActive(Button buttonType)
	{
		// ����������� HEX � �������� �����
		string hexCode = "#FFEE00"; // ��������� �����-����� FF (��������� ������������)

		Color newColor;
		if (!ColorUtility.TryParseHtmlString(hexCode, out newColor))
			Debug.LogError("������ ����������� HEX �����");

		// ������ ����� ���� ��������� ������
		ColorBlock colors = buttonType.colors;
		colors.normalColor = newColor;
		colors.highlightedColor = newColor;
		colors.selectedColor = newColor;
		colors.pressedColor = newColor;
		colors.disabledColor = newColor;
		buttonType.colors = colors;
	}

	/*
	public void ChangeWeaponWheelButtonColorToDefault(Button buttonType)
	{
		// ����������� HEX � �������� �����
		string hexCode = "#D18A24"; // ��������� �����-����� FF (��������� ������������)

		Color newColor;
		if (!ColorUtility.TryParseHtmlString(hexCode, out newColor))
			Debug.LogError("������ ����������� HEX �����");

		// ������ ����� ���� ��������� ������
		ColorBlock colors = buttonType.colors;
		//colors.normalColor = newColor;
		colors.highlightedColor = newColor;
		colors.selectedColor = newColor;
		colors.pressedColor = newColor;
		buttonType.colors = colors;

	}
	*/
	public void ChangeWeaponWheelButtonColorToDefault(Button buttonType)
	{
		// ���������� HEX-���� ��� ���� ������
		string highlightHexCode = "#D18A24FF"; // �������� ���� ��� Highlight/Press/Select
		string normalHexCode = "#5B4328FF";    // ��������� ���� ��� Normal ���������

		// ������� ������� Color ��� ����� ������
		Color highlightColor;
		Color normalColor;

		// ��������� ��� HEX-����
		if (!ColorUtility.TryParseHtmlString(highlightHexCode, out highlightColor))
		{
			Debug.LogError("������ ����������� ������� HEX �����");
		}
		if (!ColorUtility.TryParseHtmlString(normalHexCode, out normalColor))
		{
			Debug.LogError("������ ����������� ������� HEX �����");
		}

		// ������ ������� ��������� ������ ������
		ColorBlock colors = buttonType.colors;

		// ��������� ����� ����� ��� ���������� ���������
		colors.normalColor = normalColor;       // ������ ��� �������� ���������
		colors.highlightedColor = highlightColor; // ��� ����������� ���������
		colors.pressedColor = highlightColor;   // ��� �������� ���������
		colors.selectedColor = highlightColor;  // ��� ���������� ���������

		// ��������� disabledColor ��� ���������

		// ��������� ����������� ����� ������
		buttonType.colors = colors;
	}
	

}
