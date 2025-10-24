using System.Collections;
using UnityEngine;

public class GameInitiator : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject playerCamera;
	[SerializeField] private GameObject gameCanvas;
	[SerializeField] private GameObject dataPersistenceManager;
	[SerializeField] private GameObject gameSceneManager;



	private void Start()
	{
		//BindObjects();
	}

	private void BindObjects()
	{
		player = Instantiate(player);
		playerCamera = Instantiate(playerCamera);
		gameCanvas = Instantiate(gameCanvas);
		dataPersistenceManager = Instantiate(dataPersistenceManager);
		gameSceneManager = Instantiate(gameSceneManager);
	}






	/*
	// ����� ������� ����
	private void Start()
	{
		StartCoroutine(StartGame());
	}

	// ����������� ������ ������� ���������
	private IEnumerator StartGame()
	{
		Debug.Log("������ �������������...");

		yield return StartCoroutine(BindObjects()); // ���� ��������� ���������� ��������

		Debug.Log("������������� ���������.");
	}

	// �������� ����������� �����-�� ��������
	private IEnumerator BindObjects()
	{
		for (int i = 0; i < 5; i++)
		{
			Debug.Log($"����������� �������� {i}");
			yield return new WaitForSeconds(1f); // ����� �� �������
		}

		Debug.Log("�������� ��������� �������!");
	}
	*/
}
