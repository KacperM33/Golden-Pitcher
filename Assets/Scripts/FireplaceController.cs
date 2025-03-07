using UnityEngine;

public class FireplaceController : MonoBehaviour, Interactable
{
    public PlayerHealth playerHealth;
    public GameController gameController;

    // Metoda dziedziczona z interfejsu Interactable, odpowiada za interakcje z elementem gry
    public void Interact()
    {
        if (playerHealth == null)
        {
            playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
        }

        if (gameController == null)
        {
            gameController = Object.FindFirstObjectByType<GameController>();
        }

        // ustawienie ¿ycia gracza
        playerHealth.SetMaxHealth();

        // odrodzenie wszystkich przeciwników
        GameObject[] enemies = gameController.allEnemies;

        foreach (var enemy in enemies)
        {
            if (enemy.TryGetComponent(out EnemyCombat enemyCombat))
            {
                enemyCombat.Respawn();
            }
        }

        // ustawienie miejsca ogniska jako punktu odrodzenia gracza
        playerHealth.respawnPoint = transform.position;
    }
}
