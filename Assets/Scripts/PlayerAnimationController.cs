
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
	public PlayerInputsList playerInputsList;
	
	public PlayerMovementController playerMovementController;

	public PlayerCamera playerCamera;
	public GameObject playerCameraObject;

	private Animator playerAnimator;
	private string currentPlayerMovementAnimation = "";
	private string currentPlayerWeaponRightAnimation = "";
	private string currentPlayerWeaponLeftAnimation = "";

	public PlayerBehaviour playerBehaviour;

	public WeaponController weaponController;

	float lmao;
	void Start()
    {
		playerInputsList = GetComponent<PlayerInputsList>();

		playerMovementController = GetComponent<PlayerMovementController>();

		playerCamera = playerCameraObject.GetComponent<PlayerCamera>();

		playerAnimator = GetComponent<Animator>();
		ChangePlayerMovementAnimation("Idle");

		playerBehaviour = GetComponent<PlayerBehaviour>();

		weaponController = GetComponent<WeaponController>();
	}

	private void Update()
	{
		// ������� ������� ������ X
		float bruh = playerCameraObject.transform.rotation.eulerAngles.x;
		if (bruh >= 0 && bruh < 180)
		{
			lmao = bruh;
		}
		else if (bruh < 360 && bruh > -180)
		{
			lmao = bruh - 360;
		}
	
		// ����� ������� ����/����� ����� �������� �� 3�� ����
		if (playerBehaviour.IsPlayerArmed == true && playerCamera.GetCurrentPlayerCameraType() == PlayerCameraStateType.ThirdPerson.ToString())
		{
			// ��� 1: ���������� ��������� �������� (������� �������� ���������)
			float startValue = playerAnimator.GetFloat("UpDown");

			// ��� 2: ������������ ������� �������� �� ������ ���� ������
			float endValue = lmao * 0.0153846f;

			// ��� 3: ������������� ��������
			float newValue = Mathf.Lerp(startValue, endValue, Time.deltaTime * 6);

			// ��� 4: ��������� �������� � ���������
			playerAnimator.SetFloat("UpDown", newValue);
		}
		else
		{
			// ��� 1: ���������� ��������� �������� (������� �������� ���������)
			float startValue = playerAnimator.GetFloat("UpDown");

			// ��� 2: ������� ��������� ������ ���������� ����
			float endValue = 0f;

			// ��� 3: ������������� �������� �� �������� �� ����
			float newValue = Mathf.Lerp(startValue, endValue, Time.deltaTime * 6);

			// ��� 4: ��������� �������� � ���������
			playerAnimator.SetFloat("UpDown", newValue);
		}

		if (playerBehaviour.IsPlayerArmed == true && playerCamera.GetCurrentPlayerCameraType() == PlayerCameraStateType.FirstPerson.ToString())
		{
			playerAnimator.SetFloat("UpDown", 0);
		}



			// �������� PlayerMovement state ������
		if (playerMovementController.CurrentPlayerMovementStateType == "PlayerIdle")
		{
			
			ChangePlayerMovementAnimation("Idle");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerWalking")
		{
			if (playerBehaviour.IsPlayerArmed == true || (playerCamera.GetCurrentPlayerCameraType() == PlayerCameraStateType.FirstPerson.ToString()))
			{
				if (playerInputsList.GetKeyUp())
				{
					ChangePlayerMovementAnimation("Walking Forward");
				}
				else if (playerInputsList.GetKeyDown())
				{
					ChangePlayerMovementAnimation("Walking Backwards");
				}
				if (playerInputsList.GetKeyRight())
				{
					ChangePlayerMovementAnimation("Walking Right");
				}
				else if (playerInputsList.GetKeyLeft())
				{
					ChangePlayerMovementAnimation("Walking Left");
				}
			}
			else ChangePlayerMovementAnimation("Walking Forward");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerRunning")
		{

			ChangePlayerMovementAnimation("Running");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerJumping")
		{

			ChangePlayerMovementAnimation("Jumping");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerFalling")
		{

			ChangePlayerMovementAnimation("Falling");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerCrouchingIdle")
		{

			ChangePlayerMovementAnimation("CrouchingIdle");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerCrouchingWalking")
		{

			ChangePlayerMovementAnimation("CrouchingWalking");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerSliding")
		{

			ChangePlayerMovementAnimation("Sliding");
		}
		else if (playerMovementController.CurrentPlayerMovementStateType == "PlayerLedgeClimbing")
		{
			ChangePlayerMovementAnimation("Ledge Climbing");
		}




		// �������� ������
		if (weaponController.RightHandWeapon != null)
		{
			if (weaponController.RightHandWeapon.ThirdPersonWeaponModelInstance.activeInHierarchy)
			{
				playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("WeaponRight"), 1);
				ChangePlayerWeaponRightAnimation("EquipRightWeapon");
			}
			else 
			{
				ChangePlayerWeaponRightAnimation("UnequipRightWeapon");
				if (playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponRight")).IsName("UnequipRightWeapon") && playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponRight")).normalizedTime >= 0.99f)
				{
					playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("WeaponRight"), 0);
				}
			}
		}
		else
		{
				ChangePlayerWeaponRightAnimation("UnequipRightWeapon");
				if (playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponRight")).IsName("UnequipRightWeapon") && playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponRight")).normalizedTime >= 0.99f)
				{
					playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("WeaponRight"), 0);
				}
		}

		if (weaponController.LeftHandWeapon != null)
		{
			if (weaponController.LeftHandWeapon.ThirdPersonWeaponModelInstance.activeInHierarchy)
			{
				playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("WeaponLeft"), 1);
				ChangePlayerWeaponLeftAnimation("EquipLeftWeapon");
			}
			else 
			{
				ChangePlayerWeaponLeftAnimation("UnequipLeftWeapon");
				
				if (playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponLeft")).IsName("UnequipLeftWeapon") && playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponLeft")).normalizedTime >= 0.99f)
				{
					playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("WeaponLeft"), 0);
				}
			}
		}
		else
		{
			ChangePlayerWeaponLeftAnimation("UnequipLeftWeapon");

			if (playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponLeft")).IsName("UnequipLeftWeapon") && playerAnimator.GetCurrentAnimatorStateInfo(playerAnimator.GetLayerIndex("WeaponLeft")).normalizedTime >= 0.99f)
			{
				playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("WeaponLeft"), 0);
			}
		}








	}
		private void ChangePlayerMovementAnimation(string animation, float crossfade = 0.2f)
		{
			if (currentPlayerMovementAnimation != animation)
			{
				currentPlayerMovementAnimation = animation;
				playerAnimator.CrossFade(animation, crossfade);
			}
		}


	private void ChangePlayerWeaponRightAnimation(string animation, float crossfade = 0.2f)
	{
		if (currentPlayerWeaponRightAnimation != animation)
		{
			currentPlayerWeaponRightAnimation = animation;
			playerAnimator.CrossFade(animation, crossfade);
		}
	}

	private void ChangePlayerWeaponLeftAnimation(string animation, float crossfade = 0.2f)
	{
		if (currentPlayerWeaponLeftAnimation != animation)
		{
			currentPlayerWeaponLeftAnimation = animation;
			playerAnimator.CrossFade(animation, crossfade);
		}
	}
}

