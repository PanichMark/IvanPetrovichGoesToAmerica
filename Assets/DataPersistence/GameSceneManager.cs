using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour, IDataPersistence
{
	public void LoadData(GameData data)
	{
		// �������� ��� ������� �������� �����
		//string sceneName = SceneManager.GetActiveScene().name;

		// ������������� ������� �����
		//SceneManager.LoadScene(sceneName);
		//Debug.Log("Bruh!");

	}

	public void SaveData(ref GameData data)
	{
		//throw new System.NotImplementedException();
	}

}
