using System;
using UnityEditor.PackageManager;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.GraphicsBuffer;

public class PlayerCamera : MonoBehaviour
{
	PlayerInputsList playerInputsList;
	public PlayerMovementController playerMovementController;
	public Vector2 MouseRotation;
	private float MouseRotationLimit = 45f;

	private RaycastHit hit;
	
	public Transform PlayerTransform;
	private string _currentPlayerCameraType;
	private string _previousPlayerCameraType;

	public CapsuleCollider PlayerCollider;

	public PlayerCameraStateType playerCameraStateType;
	public PlayerCameraState playerCameraState;

	public float PlayerCameraDistanceX;
	public float PlayerCameraDistanceY;
	public float PlayerCameraDistanceZ;

	public float CameraRotationY;

	public Vector3 CameraForward;
	public Vector3 CameraRight;



	private bool lastHitResult = false;              // ��������� ����������� Linecast
	private bool currentHitResult = false;           // ��������� �������� Linecast




	private bool canReturn = false;     // ����������� �������� ������
	private float startTransitionTime; // ����� ������ ��������
	public float transitionDelay = 0.5f;// �������� ����� ��������� �� ������� ���������

	private float targetDistance;


	// ���������� ��� ������� �������� ��������� ����������
	private float smoothVelocity = 0f;

		private void Awake()
	{
		playerCameraStateType = PlayerCameraStateType.ThirdPerson;
	}
	void Start()
	{
		currentHitResult = lastHitResult;
		

		SetPlayerCameraState(playerCameraStateType);

		playerInputsList = GetComponent<PlayerInputsList>();
		//playerMovementController = GetComponent<PlayerMovementController>();

		//PlayerCameraDistanceX = -0.4f;
		//PlayerCameraDistanceY = -1.5f;
		//PlayerCameraDistanceZ = 0.75f;


		PlayerCameraDistanceX = -0.85f;
		PlayerCameraDistanceY = -2;
		PlayerCameraDistanceZ = 2.5f;
	}

	void Update()
	{




		MouseRotation.y += Input.GetAxis("Mouse X");
		MouseRotation.x += Input.GetAxis("Mouse Y");
		MouseRotation.x = Mathf.Clamp(MouseRotation.x, MouseRotationLimit * -1, MouseRotationLimit);

		playerCameraState.PlayerCameraPosition();

		if (playerInputsList.GetKeyChangeCameraView())
		{
			ChangePlayerCameraView();
		}

		if (playerInputsList.GetKeyEnterCutscene())
		{
			if (_currentPlayerCameraType != PlayerCameraStateType.Cutscene.ToString())
			{
				EnterCutscene();
			}
			else
			{
				ExitCutscene();
			}
		}


		if (Physics.Linecast(PlayerCollider.transform.position, transform.position, out hit))
		{


			 targetDistance = hit.distance;
		}

		Debug.Log(targetDistance);


		if (Physics.Linecast(PlayerCollider.transform.position, transform.position, out hit))
		{
			// ������ ����� ����� ������
			if (!canReturn)
			{
				// ��������� �������� ������
				canReturn = true;
				startTransitionTime = Time.time;
			}
			else
			{
				// ���������, ������ �� ������ ��������
				if (Time.time - startTransitionTime >= transitionDelay)
				{
					if (PlayerCameraDistanceZ >= 0.75f)
					{
						// ������ �������� � �������, ��� �� ����������� ����������
						PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, hit.distance, Time.deltaTime * 4f);
						//PlayerCameraDistanceZ = Mathf.SmoothDamp(PlayerCameraDistanceZ, targetDistance - 2.5f, ref smoothVelocity, 0.1f);
					}
				}
			}
		}
		else
		{
			if (PlayerCameraDistanceZ <= 2.5f )
			{

				// �������� ����������� �������� ������
				PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, 2.5f, Time.deltaTime * 4f);
				//PlayerCameraDistanceZ = Mathf.SmoothDamp(PlayerCameraDistanceZ, 2.5f, ref smoothVelocity, 0.1f);
			}

			canReturn = false; // �������� �����������
		}
		




		/*
		if (Physics.Linecast(PlayerCollider.transform.position, transform.position, out hit))
		{
			// ������ ����� ����� ������
			if (!canReturn)
			{
				// ��������� �������� ������
				canReturn = true;
				startTransitionTime = Time.time;
			}
			else
			{
				// ���������, ������ �� ������ ��������
				if (Time.time - startTransitionTime >= transitionDelay)
				{
					if (PlayerCameraDistanceZ >= 0.75f)
					{
						// ������ �������� � �������, ��� �� ����������� ����������
						PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, PlayerCameraDistanceZ - 0.1f, Time.deltaTime * 200f);
					}
				}
			}
		}
		else
		{
			if (PlayerCameraDistanceZ <= 2.5f)
			{
				// �������� ����������� �������� ������
				PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, PlayerCameraDistanceZ + 0.1f, Time.deltaTime * 200f);
			}

			canReturn = false; // �������� �����������
		}
		*/

















		/*
			if (Physics.Linecast(PlayerCollider.transform.position, transform.position, out hit))
			{

				currentHitResult = false;

				if (PlayerCameraDistanceZ >= 0.75f)
				{


						//Debug.Log("NO");
						PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, PlayerCameraDistanceZ - 0.1f, Time.deltaTime * 200f);

				}

			}
			else
			{
				currentHitResult = true;

			
				if (PlayerCameraDistanceZ <= 2.5f)
				{


						//Debug.Log("HIT");
						PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, PlayerCameraDistanceZ + 0.1f, Time.deltaTime * 200f);

				}

			}

		Debug.Log("Before Updated frame");

		Debug.Log("LastHit " + lastHitResult);
		Debug.Log("CurrentHit " + currentHitResult);



		if (currentHitResult != lastHitResult)
		{
			//Debug.Log("Bruh");
		}
			*/

			/*
		if (Physics.Linecast(PlayerCollider.transform.position, transform.position, out hit))
		{

			//currentHitResult = false;
			if (currentHitResult == lastHitResult && PlayerCameraDistanceZ >= 0.75f)
			{


				//Debug.Log("NO");
				PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, 0.75f, Time.deltaTime * 4f);

			}
		}
		else
		{
			//currentHitResult = true;
			if (currentHitResult == lastHitResult && PlayerCameraDistanceZ <= 2.5f  )
			{


				//Debug.Log("HIT");
				PlayerCameraDistanceZ = Mathf.Lerp(PlayerCameraDistanceZ, 2.5f, Time.deltaTime * 4f);

			}
		}

		//lastHitResult = currentHitResult;

		Debug.Log("After Updated frame");

		Debug.Log("LastHit " + lastHitResult);
		Debug.Log("CurrentHit " + currentHitResult);
		
		*/
		// ��������� ������� ��������� ��� ���������� �����



		CameraForward = transform.forward;
			CameraRight = transform.right;

			transform.rotation = Quaternion.Euler(-MouseRotation.x, MouseRotation.y, 0);

			CameraRotationY = transform.eulerAngles.y;
		
	}
	public void SetPlayerCameraState(PlayerCameraStateType playerCameraStateType)
	{
		PlayerCameraState newState;

		if (playerCameraStateType == PlayerCameraStateType.FirstPerson)
		{
			newState = new FirstPersonPlayerCameraState(this);
		}
		else if (playerCameraStateType == PlayerCameraStateType.ThirdPerson)
		{
			newState = new ThirdPersonPlayerCameraState(this);
		}
		else if (playerCameraStateType == PlayerCameraStateType.Cutscene)
		{
			newState = new CutscenePlayerCameraState(this);
		}
		else
		{
			newState = null;
		}

		playerCameraState = newState;
	}
	public void ChangePlayerCameraView()
	{
		playerCameraState.ChangePlayerCameraView();
	}
	public void EnterCutscene()
	{
		playerCameraState.EnterCutscene();
	}
	public void ExitCutscene()
	{
		playerCameraState.ExitCutscene();
	}
	public void FirstPersonCameraTransform()
	{
		transform.position = PlayerTransform.position + Quaternion.Euler(0, MouseRotation.y, 0) *
		new Vector3(0, playerMovementController.PlayerCurrentHeight, 0.05f);
	}
	public void ThirdPersonCameraTransform()
	{
		transform.position = PlayerTransform.position - Quaternion.Euler(-MouseRotation.x, MouseRotation.y, 0) *
		new Vector3(PlayerCameraDistanceX, PlayerCameraDistanceY, PlayerCameraDistanceZ);
	}
	public void CutsceneCameraTransform()
	{
		transform.position = new Vector3(0, 5, -7);
	}
	public void SetPlayerCameraType(PlayerCameraStateType newCameraType)
	{
		/*
		if (newCameraType < 0 || newCameraType > 3)
		{
			Debug.Log("Wrong PlayerCameraType set: " + newCameraType);
			return;
		}
		*/
		_previousPlayerCameraType = _currentPlayerCameraType;
        _currentPlayerCameraType = newCameraType.ToString();
		Debug.Log("Previous Cam: " + _previousPlayerCameraType);
		Debug.Log("Current Cam: " + _currentPlayerCameraType);
		
	}
	public string GetCurrentPlayerCameraType()
	{
		return _currentPlayerCameraType.ToString();
	}
	public string GetPreviousPlayerCameraType()
	{
		return _previousPlayerCameraType.ToString();
	}
}
