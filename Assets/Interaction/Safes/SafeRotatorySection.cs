using UnityEngine;
using System.Collections;

public class SafeRotatorySection : MonoBehaviour, IInteractable
{
	[SerializeField] private int safeSectionSlotNumber;
	[SerializeField] [Range(0, 9)] private int correctSectionPosition;
	public int CorrectSectionPosition => correctSectionPosition; // ������ ������ ����� ��������� ��������
	public bool IsSectionPositionCorrect { get; private set; }
	public int currentSectionPosition { get; private set; }

	private float sectionRotationSpeed = 0.15f;
	private Coroutine sectionCoroutine; // ���������� ��� �������� ������� ��������

	public string InteractionItemName => safeSectionSlotNumber.ToString();
	public virtual string InteractionHint => $"��������� ������ #{InteractionItemName}";

	public void Interact()
	{
		// ���������, ���� �� ��� ���������� ��������
		if (sectionCoroutine == null)
		{
			// ����� ���� ���������� ������� �������� � ������ �����, ���� ��������������� �����
			sectionCoroutine = StartCoroutine(RotateSmoothly(sectionRotationSpeed));
		}
	}

	IEnumerator RotateSmoothly(float duration)
	{
		if (currentSectionPosition < 9)
		{
			currentSectionPosition++;
		}
		else
		{
			currentSectionPosition -= 9;
		}
		
		Quaternion rotateFrom = transform.localRotation;
		Quaternion rotateTo = transform.localRotation * Quaternion.Euler(0, 36, 0);

		float elapsedTime = 0f;

		while (elapsedTime < duration)
		{
			transform.localRotation = Quaternion.Slerp(rotateFrom, rotateTo, elapsedTime / duration);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		Debug.Log($"Section #{InteractionItemName} new position is {currentSectionPosition}");

		if (currentSectionPosition == correctSectionPosition)
		{
			IsSectionPositionCorrect = true;
			Debug.Log($"Section #{InteractionItemName} CORRECT");
		}
		else
		{
			IsSectionPositionCorrect = false;
		}

		transform.localRotation = rotateTo; // �������������� ������������� ��������� ���������
		sectionCoroutine = null; // ����������� ���������� ����� ���������� ��������
	}

	public void SetSectionPositionToCorrect()
	{
		IsSectionPositionCorrect = true;
	}
}
