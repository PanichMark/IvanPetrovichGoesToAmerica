using TMPro;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
	public float interactionRange = 50f; // �������� ��������������
	public TextMeshProUGUI interactionText; // ��������� (����������� ������� ����� Inspector)
	public PlayerCamera playerCamera;
	public GameObject PlayerCameraObject;
	private PlayerInputsList playerInputsList; // ������ ������ �����
	private Material outlineMaterial; // ��������� ��������
	private Renderer currentRenderer; // ���������� ��� �������� �������� Renderer
	private Material originalMaterial; // ���������� ��� �������� ������������� ���������
	private bool IsAbleCheckForOldMaterial;

	void Start()
	{
		playerInputsList = GetComponent<PlayerInputsList>(); // �������� ������ �������� ������
		playerCamera = PlayerCameraObject.GetComponent<PlayerCamera>();
		outlineMaterial = Resources.Load<Material>("WhiteOutline"); // ��������� ��������� ��������
		IsAbleCheckForOldMaterial = true;
	}

	/*
	private void OnDrawGizmos()
	{
		if (playerCamera != null)
		{
			Gizmos.color = Color.red; // ���� ����
			Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionRange);
		}
	}
	*/

	void Update()
	{
		//Debug.Log("Current: " + currentRenderer);
		//Debug.Log("Original: " + originalMaterial);
		//Debug.Log("Outline: " + outlineMaterial);


		if (interactionText != null)
			interactionText.text = "";

		RaycastHit hitInfo;
		bool isHit = Physics.Raycast(
			playerCamera.transform.position,
			playerCamera.transform.forward,
			out hitInfo,
			interactionRange
		);


		if (isHit && hitInfo.collider != null && hitInfo.collider.tag == "Interactable") // �������� �� ���� � �� null
		{
			var interactableObj = hitInfo.collider.GetComponent<IInteractable>();

			if (interactableObj != null) // �������� �� ������� ����������
			{
				Renderer renderer = hitInfo.collider.GetComponent<Renderer>();
				if (renderer != null)
				{
					currentRenderer = renderer;

					if (IsAbleCheckForOldMaterial == true)
					{ 
						originalMaterial = renderer.material;
						IsAbleCheckForOldMaterial = false;

					}

					// ��������� ������������ �������� � ���������� Renderer
					if (renderer.material != outlineMaterial)
					{
					
						renderer.material = outlineMaterial;
					}

					
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
			// ���� ������ ����� �� ���� ��������������, ���������� �������� ��������
			if (currentRenderer != null)
			{
			//	Debug.Log("BRUH!");

				currentRenderer.material = originalMaterial;
				currentRenderer = null;
				originalMaterial = null;
				IsAbleCheckForOldMaterial = true;
			}
		}
	}

	// ������� ��� ����� ���������� (��� ��������� �������)
	private void ChangeMaterialToOutline(GameObject obj)
	{
		Renderer renderer = obj.GetComponent<Renderer>();
		if (renderer != null && outlineMaterial != null)
		{
			renderer.material = outlineMaterial;
		}
		else
		{
			Debug.LogWarning("���������� ��� Render-����������� ���.");
		}
	}
}