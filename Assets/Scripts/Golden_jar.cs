using UnityEngine;

public class Golden_jar : MonoBehaviour, Interactable
{
    public GameController gameController;
    public Coins coins;

    [SerializeField] Dialog dialog;

    private void Start()
    {
        if (gameController == null)
        {
            gameController = Object.FindFirstObjectByType<GameController>();
        }

        if (coins == null)
        {
            coins = Object.FindFirstObjectByType<Coins>();
        }
    }

    // Metoda dziedziczona z interfejsu Interactable, odpowiada za interakcje z elementem gry
    public void Interact()
    {
        // uruchomienie dialogu specjalnego NPC
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));

        coins.currentCoins = 0;

        // zlikwidowanie wszystkich przeciwników przez specjalnego NPC
        GameObject[] enemies = gameController.allEnemies;

        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent(out EnemyCombat enemyCombat))
            {
                enemyCombat.Kill();
            }
        }
    }
}
