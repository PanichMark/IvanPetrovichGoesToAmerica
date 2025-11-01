using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorSCENE : DoorAbstract
{
	public override string InteractionItemName => "�����";

	//private float doorOpeningSpeed = 200f; // �������� ��������-��������

	//private Coroutine currentAnimation;     // ���������� ��� �������� �������� ��������

	//private Quaternion openedRotation;       // ������� ��������� �������� �����
//	private Quaternion closedRotation;     // ������� ��������� �������� �����

	[SerializeField] private string goToSceneName;

	public override void Interact()
	{
		//string sceneName = SceneManager.GetActiveScene().name;

		SceneManager.LoadSceneAsync(goToSceneName);
	}

	

	
}