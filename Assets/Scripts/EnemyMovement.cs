using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool isChasing;

    public Rigidbody2D rb;
    private Transform player;

    void Start()
    {

    }

    void Update()
    {
        if (isChasing == true)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
    }

    // Metoda aktywowana podczas kolizji przeciwnika z graczem, która pobiera pozycjê gracza, aby przeciwnik zacz¹³ go goniæ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }

    // Metoda aktywowana gdy gracz opuœci kolizjê z przeciwnikiem, aby ten przesta³ go goniæ
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            isChasing = false;
        }
    }
}
