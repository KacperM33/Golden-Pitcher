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

    // Metoda do zmieniania punkt�w �ycia gracza
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

    // Metoda ustawiaj�ca �ycie gracza na pe�n� warto��
    public void SetMaxHealth()
    {
        currentHealth = maxhealth;
        slider.value = currentHealth;
        playerController.currentEnergy = playerController.maxEnergy;
        playerController.slider.value = playerController.currentEnergy;
    }

    // Metoda wywo�ywana przez przycisk "Wskrze�" na ekranie po�miertlnym
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

        // odrodzenie wszystkich przeciwnik�w
        GameObject[] enemies = gameController.allEnemies;

        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent(out EnemyCombat enemyCombat))
            {
                enemyCombat.Respawn();
                Debug.Log("RESPAWN");
            }
        }
        // ustawienie �ycia gracza na pe�ne
        SetMaxHealth();

        // przeniesienie gracza do punktu odrodzenia
        transform.position = respawnPoint;

        // wy�wietlenie dialogu dla odrodzenia
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));

        Time.timeScale = 1;
    }

    // Metoda do wy��czenia aplikacji w momencie klikni�cia przycisku "Wyjd� z gry" na ekranie po�miertlnym
    public void Quit()
    {
        Application.Quit();
    }
}
