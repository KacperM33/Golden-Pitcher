using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GateController : MonoBehaviour, Interactable
{
    private Coins coins;
    public int requiredCoins;

    [SerializeField] Dialog dialog;

    // Metoda dziedziczona z interfejsu Interactable, odpowiada za interakcje z elementem gry
    public void Interact()
    {
        if (coins == null)
        {
            coins = Object.FindFirstObjectByType<Coins>();
        }

        if (coins.currentCoins >= requiredCoins)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }
}
