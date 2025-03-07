using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject DeadPanel;

    public int currentHealth;
    public int maxhealth;
    public Slider slider;

    public Vector3 respawnPoint;

    public GameController gameController;
    public PlayerController playerController;

    [SerializeField] Dialog dialog;

    private float timer = 0f;

    void Start()
    {
        currentHealth = 50;
        respawnPoint = transform.position;
        slider.maxValue = maxhealth;
        slider.value = currentHealth;

        if (gameController == null)
        {
            gameController = Object.FindFirstObjectByType<GameController>();
        }

        if (playerController == null)
        {
            playerController = Object.FindFirstObjectByType<PlayerController>();
        }
    }

    void Update()
    {
        
    }

    // Metoda do zmieniania punktów ¿ycia gracza
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            playerController.isDead = true;
            DeadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Metoda ustawiaj¹ca ¿ycie gracza na pe³n¹ wartoœæ
    public void SetMaxHealth()
    {
        currentHealth = maxhealth;
        slider.value = currentHealth;
        playerController.currentEnergy = playerController.maxEnergy;
        playerController.slider.value = playerController.currentEnergy;
    }

    // Metoda wywo³ywana przez przycisk "Wskrzeœ" na ekranie poœmiertlnym
    public void Resp()
    {   
        Resp2();
        DeadPanel.SetActive(false);
    }

    // Metoda odpowiedzialna za odrodzenie gracza
    public void Resp2()
    {
        if (gameController == null)
        {
            gameController = Object.FindFirstObjectByType<GameController>();
        }

        // odrodzenie wszystkich przeciwników
        GameObject[] enemies = gameController.allEnemies;

        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent(out EnemyCombat enemyCombat))
            {
                enemyCombat.Respawn();
                Debug.Log("RESPAWN");
            }
        }
        // ustawienie ¿ycia gracza na pe³ne
        SetMaxHealth();

        // przeniesienie gracza do punktu odrodzenia
        transform.position = respawnPoint;

        // wyœwietlenie dialogu dla odrodzenia
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));

        Time.timeScale = 1;
    }

    // Metoda do wy³¹czenia aplikacji w momencie klikniêcia przycisku "WyjdŸ z gry" na ekranie poœmiertlnym
    public void Quit()
    {
        Application.Quit();
    }
}
