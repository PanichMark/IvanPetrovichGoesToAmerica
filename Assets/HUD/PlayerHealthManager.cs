using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
	public static PlayerHealthManager Instance { get; private set; } // ����������� ���� ����������

	public Slider HealthBarSlider;
    public Button HealingItemButton;
    public TextMeshProUGUI HealingItemNumber;
    public int MaxPlayerHealth { get; private set; } = 100;
    public int CurrentPlayerHealth { get; private set; } = 30;

    public int MaxHealingItemsNumber { get; private set; } = 9;

	public int CurrentHealingItemsNumber { get; private set; } = 5;

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

	void Start()
    {
        HealingItemButton.onClick.AddListener(() => UseHealingItem());

        HealthBarSlider.maxValue = MaxPlayerHealth;

    }

    void Update()
    {
        HealthBarSlider.value = CurrentPlayerHealth;

        HealingItemNumber.text = CurrentHealingItemsNumber.ToString();
	}

    private void UseHealingItem()
    {
        if (CurrentHealingItemsNumber > 0)
        {
            if (CurrentPlayerHealth < MaxPlayerHealth)
            {
            Debug.Log("Used Healing Item");
            CurrentHealingItemsNumber--;

                CurrentPlayerHealth += 34;
            }
            else Debug.Log("Health is already Full");
		}
		else Debug.Log("0 Healing Items");

	}
    public void AddHealingItem()
    {
		if (CurrentHealingItemsNumber < 9)
        {
			Debug.Log("Added Healing Item");
			CurrentHealingItemsNumber++;
		}
        else Debug.Log("Max Healing Items");

	}

}
