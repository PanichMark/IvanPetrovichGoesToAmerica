using UnityEngine;
public class PlayerCameraFirstPersonRender : MonoBehaviour
{
	PlayerCamera playerCamera;
	WeaponController weaponController;
	public PlayerCameraStateType playerCameraStateType;

	public GameObject PlayerCameraObject;

	public GameObject PlayerHeadParent;
	public GameObject PlayerHandRightParent;
	public GameObject PlayerHandLeftParent;

	void Start()
	{
		playerCamera = PlayerCameraObject.GetComponent<PlayerCamera>();
		weaponController = GetComponent<WeaponController>();
	}

	private void Update()
	{
		 if (playerCamera.IsPlayerCameraFirstPerson)
    {
        if (weaponController.RightHandWeapon != null)
        {
            ShowPlayerWeapon(weaponController.RightHandWeapon.FirstPersonWeaponModelInstance, false); // ������ ����, ������ ������� ���� �����, ��� �����
            HidePlayerWeapon(weaponController.RightHandWeapon.ThirdPersonWeaponModelInstance, true);  // ������ ����, ������ �������� ���� ������, �� ����������� ����
        }

        if (weaponController.LeftHandWeapon != null)
        {
            ShowPlayerWeapon(weaponController.LeftHandWeapon.FirstPersonWeaponModelInstance, false);   // ������ ����, ������ ������� ����, ���������� ������ ����
            HidePlayerWeapon(weaponController.LeftHandWeapon.ThirdPersonWeaponModelInstance, true);   // ������ ����, ������ �������� ����, ���������� ������ ����
        }
    }
    else
    {
        if (weaponController.RightHandWeapon != null)
        {
            ShowPlayerWeapon(weaponController.RightHandWeapon.ThirdPersonWeaponModelInstance, true);  // ������ ����, ������ �������� ����, ���������� � ����������� ����
            HidePlayerWeapon(weaponController.RightHandWeapon.FirstPersonWeaponModelInstance, false); // ������ ����, ������ ������� ����, ������ �� ����� � ��� �����
        }

        if (weaponController.LeftHandWeapon != null)
        {
            ShowPlayerWeapon(weaponController.LeftHandWeapon.ThirdPersonWeaponModelInstance, true);   // ����� ����, ������ �������� ����, ���������� ������ ����
            HidePlayerWeapon(weaponController.LeftHandWeapon.FirstPersonWeaponModelInstance, false);  // ����� ����, ������ ������� ����, ���������� ������ ����
        }
    }
	}
	void FixedUpdate()
	{
		if (playerCamera.IsPlayerCameraFirstPerson == true) 
		{
			HideBodyPart(PlayerHeadParent);

			if (weaponController.RightHandWeapon != null)
			{
				HideBodyPart(PlayerHandRightParent);
			}
			else
			{
				ShowBodyPart(PlayerHandRightParent);
			}

			if (weaponController.LeftHandWeapon != null)
			{
				HideBodyPart(PlayerHandLeftParent);
			}
			else
			{
				ShowBodyPart(PlayerHandLeftParent);
			}
		}
		else 
		{
			ShowBodyPart(PlayerHeadParent);

			ShowBodyPart(PlayerHandRightParent);
			ShowBodyPart(PlayerHandLeftParent);
		}
	}

	public void ShowBodyPart(GameObject rootObj)
	{
		// �������� ��� ������� (������� �������� �������)
		Renderer[] renderers = rootObj.GetComponentsInChildren<Renderer>(true);

		// ���������� ��� ������� � �������� ������������ �����
		foreach (Renderer renderer in renderers)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			}
		}
	}

	public void HideBodyPart(GameObject rootObj)
	{
		// �������� ��� ������� (������� �������� �������)
		Renderer[] renderers = rootObj.GetComponentsInChildren<Renderer>(true);

		// ���������� ��� ������� � �������� ������������ �����
		foreach (Renderer renderer in renderers)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
			}
		}
	}


	/*
	public void ShowPlayerWeapon(GameObject rootObj)
	{
		// �������� ��� ������� (������� �������� �������)
		Renderer[] renderers = rootObj.GetComponentsInChildren<Renderer>(true);

		// ���������� ��� ������� � �������� ������������ �����
		foreach (Renderer renderer in renderers)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				//renderer.enabled = true;
				renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			}
		}
	}

	public void HidePlayerWeapon(GameObject rootObj)
	{
		// �������� ��� ������� (������� �������� �������)
		Renderer[] renderers = rootObj.GetComponentsInChildren<Renderer>(true);

		// ���������� ��� ������� � �������� ������������ �����
		foreach (Renderer renderer in renderers)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				if (playerCamera.IsPlayerCameraFirstPerson)
				{
					//renderer.enabled = false;
					renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
				}
				
				else
				{
					renderer.enabled = false;
					renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
				}
			}
		}
	}
	*/
	public void ShowPlayerWeapon(GameObject weaponRoot, bool castShadows)
	{
		Renderer[] renderers = weaponRoot.GetComponentsInChildren<Renderer>(true);

		foreach (Renderer renderer in renderers)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				renderer.enabled = true;                                   // �������� ������

				if (castShadows)
				{
					renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;  // �������� ������������ �����
				}
				else
				{
					renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; // ��������� ������������ �����
				}
			}
		}
	}

	public void HidePlayerWeapon(GameObject weaponRoot, bool allowShadows)
	{
		Renderer[] renderers = weaponRoot.GetComponentsInChildren<Renderer>(true);

		foreach (Renderer renderer in renderers)
		{
			if (renderer is MeshRenderer || renderer is SkinnedMeshRenderer)
			{
				if (playerCamera.IsPlayerCameraFirstPerson)
				{
					renderer.enabled = true;
				}
				else
				{
					renderer.enabled = false;
				}

				if (!allowShadows)
				{
					renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; // ��������� ��������� ������������ �����
				}
				else
				{
					renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly; // ��������� ������ ������������ �����
				}
				
			}
		}
	}


}
