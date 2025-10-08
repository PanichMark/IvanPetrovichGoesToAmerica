using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    PlayerInputsList playerInputsList;
	public Canvas canvas; // ��������� ��� Canvas ����
	void Start()
    {
        playerInputsList = GetComponent<PlayerInputsList>();
    }

    void Update()
    {
		if (playerInputsList.GetKeyLeftHandWeaponWheel() == true)
		{
			EnableCanvas();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		else
		{
			DisableCanvas();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}


	private void EnableCanvas()
	{
		// �������� �������������� � Canvas
		//canvas.interactable = true;
	//	canvas.blocksRaycasts = true;
		canvas.gameObject.SetActive(true); // ������ Canvas �������
	}

	private void DisableCanvas()
	{
		// ��������� �������������� � Canvas
		//canvas.interactable = false;
		//canvas.blocksRaycasts = false;
		canvas.gameObject.SetActive(false); // ������ Canvas ���������
	}
}
