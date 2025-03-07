using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 2;
    public float fastSpeed = 6;
    public float moveSpeed = 2;

    public bool isMoving;

    public Vector2 input;

    public Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    public int currentEnergy;
    public int maxEnergy;
    public Slider slider;
    private float energyTimer = 0f;

    public PlayerCombat playerCombat;
    public PlayerHealth playerHealth;
    public PauseScript pauseScript;

    public bool isDead = false;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.applyRootMotion = false;
        }
    }

    void Start()
    {
        currentEnergy = 5;
        slider.maxValue = maxEnergy;
        slider.value = currentEnergy;
    }


    // Metoda update
    public void HandleUpdate()
    {
        if (playerCombat == null)
        {
            playerCombat = Object.FindFirstObjectByType<PlayerCombat>();
        }
        if (playerHealth == null)
        {
            playerHealth = Object.FindFirstObjectByType<PlayerHealth>();
        }

        // wywo³anie ataku gdy gracz kliknie lewy przycisk myszy
        if (Input.GetMouseButtonDown(0))
        {
            playerCombat.Attack();
        }

        // poruszanie siê gracza
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
			input.y = Input.GetAxisRaw("Vertical");

			if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
				animator.SetFloat("moveY", input.y);
                
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);

        // wywo³anie interakcji gdy gracz kliknie przycisk E
        if (Input.GetKeyDown(KeyCode.E))
            Interact();

        // zmniejszanie energii gdy gracz biegnie
        if (Input.GetKey(KeyCode.LeftShift) && currentEnergy > 0 && isMoving == true)
        {
            moveSpeed = fastSpeed;

            energyTimer += Time.deltaTime;

            if (energyTimer >= 1f)
            {
                energyTimer = 0f;
                if (currentEnergy > 0)
                {
                    currentEnergy -= 1;
                    slider.value = currentEnergy;
                }
            }
        }
        else
        {
            moveSpeed = normalSpeed;

            energyTimer += Time.deltaTime;

            if (energyTimer >= 2f)
            {
                energyTimer = 0f;
                if (currentEnergy < maxEnergy)
                {
                    currentEnergy += 1;
                    slider.value = currentEnergy;
                }
            }
        }
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    // Metoda obs³uguj¹ca poruszanie siê postaci gracza
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            if (isDead == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            else
            {
                targetPos = playerHealth.respawnPoint;
                isDead = false;
                yield return null;
            }

        }
        transform.position = targetPos;

        isMoving = false;
    }

    // Metoda sprawdzaj¹ca czy gracz mo¿e iœæ w danym kierunku
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
}
