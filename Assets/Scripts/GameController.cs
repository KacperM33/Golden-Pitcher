using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public GameObject[] allEnemies;

    GameState state;
    private void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (playerController != null)
        {
            playerController = Object.FindFirstObjectByType<PlayerController>();
        }

        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    // Sprawdzanie stanu gry w ka¿dej klatce
    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();

        } else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
    }
}
