using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour, IDataPersistence
{
	public static GameSceneManager Instance { get; private set; } // ����������� ���� ����������

	private void Awake()
	{
		// ������� Singleton: ������������� �������� ������� ����������
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject); // ����������� ��� ����� �������
		}
		else
		{
			Destroy(gameObject); // ���������� ������ ����������
		}
	}
	public void LoadData(GameData data)
	{

		string sceneName = SceneManager.GetActiveScene().name;

		SceneManager.LoadScene(sceneName);
		Debug.Log("Scene reloaded");

	}

	public void SaveData(ref GameData data)
	{
		//throw new System.NotImplementedException();
	}

}
