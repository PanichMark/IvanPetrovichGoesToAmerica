using UnityEngine;
using System.Collections;

public class DoorSingleDoor : DoorAbstract
{
	public override string InteractionItemName => "�����";

	private float doorOpeningSpeed = 200f; // �������� ��������-��������

	private Coroutine currentAnimation;     // ���������� ��� �������� �������� ��������

	private Quaternion openedRotation;       // ������� ��������� �������� �����
	private Quaternion closedRotation;     // ������� ��������� �������� �����

	void Start()
	{
		// ��������� ��������� ��������
		Vector3 openedEulerAngles = new Vector3(0, 0, 90);
		openedRotation = Quaternion.Euler(openedEulerAngles);

		Vector3 closedEulerAngles = new Vector3(0, 0, 0);
		closedRotation = Quaternion.Euler(closedEulerAngles);

		IsDoorOpened = false;
	}

	public override void Interact()
	{
		// ������������� ����� ���������� ��������, ���� ��� ����������
		if (currentAnimation != null)
		{
			StopCoroutine(currentAnimation);
		}

		if (!IsDoorOpened)
		{
			currentAnimation = StartCoroutine(OpenDoor()); // �������� ����� ��������
		}
		else
		{
			currentAnimation = StartCoroutine(CloseDoor()); // �������� ����� ��������
		}
	}

	private void Update()
	{
		//Debug.Log(currentAnimation);
	}

	IEnumerator OpenDoor()
	{
		Debug.Log($"���� ������� {InteractionItemName}");
		IsDoorOpened = true;

		while (Quaternion.Angle(transform.localRotation, openedRotation) > 0.1f)
		{
			transform.localRotation = Quaternion.RotateTowards(transform.localRotation, openedRotation, Time.deltaTime * doorOpeningSpeed);
			yield return null;
		}

		currentAnimation = null;
	}

	IEnumerator CloseDoor()
	{
		Debug.Log($"���� ������� {InteractionItemName}");
		IsDoorOpened = false;

		while (Quaternion.Angle(transform.localRotation, closedRotation) > 0.1f)
		{
			transform.localRotation = Quaternion.RotateTowards(transform.localRotation, closedRotation, Time.deltaTime * doorOpeningSpeed);
			yield return null;
		}

		currentAnimation = null;
	}
}