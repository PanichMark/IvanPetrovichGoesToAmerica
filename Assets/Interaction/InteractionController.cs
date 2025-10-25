using TMPro;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
	private float interactionRange = 50f; // �������� ��������������
	public TextMeshProUGUI interactionText; // ��������� (����������� ������� ����� Inspector)
	public PlayerCamera playerCamera;
	public GameObject PlayerCameraObject;
	private PlayerInputsList playerInputsList; // ������ ������ �����
	private GameObject previousInteractableItem; // ���������� ��� �������� ����������� �������
	private GameObject currentInteractableItem; // ������� ������ ��������������

	private RaycastHit hitInfo;
	private bool isHit;

	void Start()
	{
		playerInputsList = GetComponent<PlayerInputsList>(); // �������� ������ �������� ������
		playerCamera = PlayerCameraObject.GetComponent<PlayerCamera>();
	}

	void Update()
	{
		if (playerCamera.CurrentPlayerCameraStateType == "FirstPerson")
		{
			interactionRange = 2.5f;
		}
		if (playerCamera.CurrentPlayerCameraStateType == "ThirdPerson")
		{
			interactionRange = 2f + playerCamera.PlayerCameraDistanceZ;
		}

		if (interactionText != null)
			interactionText.text = "";

		if (playerCamera != null)
		{
			isHit = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionRange);
		}

		if (isHit && hitInfo.collider != null && hitInfo.collider.tag == "Interactable")
		{
			var interactableObj = hitInfo.collider.GetComponent<IInteractable>();

			if (interactableObj != null)
			{
				GameObject renderer = hitInfo.collider.gameObject;

				if (renderer != null)
				{
					currentInteractableItem = renderer;

					// ����� ������ ������, ���������, ��������� �� ��
					if (previousInteractableItem != null && previousInteractableItem != currentInteractableItem)
					{
						// ���������� ������ �������� �� �����, ���������� ���� �����������
						previousInteractableItem.layer = LayerMask.NameToLayer("Default");
					}

					// ������ ����� ���� ��� �������� �������
					currentInteractableItem.layer = LayerMask.NameToLayer("Outline");
				}

				// ������������� ��������� � ������ �������
				interactionText.text = $"{interactableObj.InteractionHint}\n������� {playerInputsList.GetNameOfKeyInteract()}";

				// �������� �� ������� ������
				if (playerInputsList.GetKeyInteract())
				{
					interactableObj.Interact(); // ��������� ������� ��������������
				}
			}
			else
			{
				Debug.LogWarning("������ � ����� \"Interactable\" �� �������� ��������� IInteractable.");
			}
		}
		else
		{
			// ���� ������ ����� �� ���� ��������������
			if (currentInteractableItem != null)
			{
				currentInteractableItem.layer = LayerMask.NameToLayer("Default");
			}

			// ������� ������� ������
			currentInteractableItem = null;
		}

		// ���������� ������� ������ ��� ���������� ��� ���������� �����
		previousInteractableItem = currentInteractableItem;
	}
}