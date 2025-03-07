using UnityEngine;
using UnityEngine.Windows;

public class PlayerCombat : MonoBehaviour
{
    public EnemyCombat enemyCombat;
    private bool isEnemyInRange = false;

    public Animator animator;

    private bool isAttacking = false;

    // Metoda wywo�ywana podczas wej�cia gracza w kolizj� z przeciwnikiem
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (enemyCombat == null)
            {
                enemyCombat = collision.gameObject.GetComponent<EnemyCombat>();
            }
            isEnemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyCombat = null;
        isEnemyInRange = false;
    }

    // Metoda dla ataku gracza, wywo�ywana w momencie klikni�cia lewego przycisku myszy
    public void Attack()
    {
        if (isAttacking == false)
        {   
            isAttacking = true;
            animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.applyRootMotion = false;
            }

            animator.SetBool("Attack", true);

            if (isEnemyInRange == true)
            {
                if (enemyCombat == null)
                {
                    enemyCombat = Object.FindFirstObjectByType<EnemyCombat>();
                }

                enemyCombat.Damage();
            }
        }
    }

    // Metoda do resetowania ataku, u�ywana do animacji
    public void ResetAttack()
    {
        animator.SetBool("Attack", false);
        isAttacking = false;
    }
}
