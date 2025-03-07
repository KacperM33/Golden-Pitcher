using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage = 20;
    public int health = 30;

    public EnemyMovement enemyMovement;
    public GameController gameController;

    public Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    // Metoda aktywowana podczas kolizji gracza z przeciwnkiem
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }

    // Metoda odpowiedzialna za zadawanie obra¿eñ przeciwnikom
    public void Damage()
    {
        health -= 10;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // Metoda odpowiedzialna za odradzanie siê przeciwników
    public void Respawn()
    {
        if (enemyMovement == null)
        {
            enemyMovement = Object.FindFirstObjectByType<EnemyMovement>();
        }

        enemyMovement.isChasing = false;
        transform.position = spawnPoint;
        health = 30;
        gameObject.SetActive(true);
    }

    // Metoda odpowiedzialna za unicestwienie przeciwnków, wywo³ywana przez specjalnego npc
    public void Kill()
    {
        Destroy(gameObject);
    }
}
