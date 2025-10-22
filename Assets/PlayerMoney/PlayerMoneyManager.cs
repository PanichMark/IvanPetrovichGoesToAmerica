using UnityEngine;
using TMPro;

public class PlayerMoneyManager : MonoBehaviour
{
	public static PlayerMoneyManager Instance { get; private set; } // ����������� ���� ����������
	public PlayerInputsList playerInputsList;
	public TMP_Text PlayerMoneyText;

    public int PlayerMoney { get; private set; } = 200;

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


	private void Start()
	{
		playerInputsList = GetComponent<PlayerInputsList>();
		UpdateMoneyDisplay(); // ����� ��������� ����� �������� ���������
	}

	private void Update()
	{
		//Debug.Log(PlayerMoney);
	}
	public void AddMoney(int moneyAmmount)
    {
        if (moneyAmmount < 0)
        {
            Debug.Log("Can't add negative Money!");
        }
        else
        {
            PlayerMoney += moneyAmmount;
			UpdateMoneyDisplay(); // ����� ��������� ����� �������� ���������
		}
    }
	public void DeductMoney(int moneyAmmount)
	{
		if (moneyAmmount > 0)
		{
			Debug.Log("Can't deduct positive Money!");
		}
		else if (moneyAmmount < -PlayerMoney)
		{
			Debug.Log("Not enought Money!");
		}
		else
		{
			PlayerMoney += moneyAmmount;
			UpdateMoneyDisplay(); // ����� ��������� ����� �������� ���������
		}
	}
	private void UpdateMoneyDisplay()
	{
		if (PlayerMoneyText != null)
		{
			PlayerMoneyText.text = PlayerMoney.ToString(); // ����������� ����� ��� ������ �����
		}
	}
}
