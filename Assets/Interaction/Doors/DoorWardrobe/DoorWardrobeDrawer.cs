using UnityEngine;
using System.Collections;

public class DoorWardrobeDrawer : DoorAbstract
{
	public override string InteractionItemName => "��������� ����";

	private float drawerOpeningSpeed = 3f; // �������� ��������-�������� �����

	private Coroutine currentAnimation;     // ���������� ��� �������� �������� ��������

	private Vector3 openedPosition;        // �������� ��������� �����
	private Vector3 closedPosition;        // �������� ��������� �����

	void Start()
	{
		// ��������� ��������� ��������� �����
		closedPosition = transform.localPosition;

		// ��������� ���� ����� �� ��� Z �� 0.45 �������
		openedPosition = transform.localPosition + new Vector3(0, 0, 0.45f);

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
			currentAnimation = StartCoroutine(OpenDrawer()); // �������� ����� ��������
		}
		else
		{
			currentAnimation = StartCoroutine(CloseDrawer()); // �������� ����� ��������
		}
	}

	IEnumerator OpenDrawer()
	{
		Debug.Log($"��� ������ {InteractionItemName}");
		IsDoorOpened = true;

		while (Mathf.Abs(transform.localPosition.z - openedPosition.z) > 0.001f)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, openedPosition, Time.deltaTime * drawerOpeningSpeed);
			yield return null;
		}

		currentAnimation = null;
	}

	IEnumerator CloseDrawer()
	{
		Debug.Log($"��� ������ {InteractionItemName}");
		IsDoorOpened = false;

		while (Mathf.Abs(transform.localPosition.z - closedPosition.z) > 0.001f)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, closedPosition, Time.deltaTime * drawerOpeningSpeed);
			yield return null;
		}

		currentAnimation = null;
	}
}