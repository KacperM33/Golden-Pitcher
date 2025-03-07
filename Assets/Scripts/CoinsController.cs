using UnityEngine;

public class CoinsController : MonoBehaviour, Interactable
{
    private Coins coins;

    // Metoda dziedziczona z interfejsu Interactable, tutaj odpowiedzialna za zbieranie z³otych dzbanów
    public void Interact()
    {
        if (coins == null)
        {
            coins = Object.FindFirstObjectByType<Coins>();
        }

        // Wywo³anie metody zwiêkszaj¹cej liczbê zebranych z³otych dzbanów i zniszczenie podniesionego z³otego dzbana
        coins.IncrementCoins();
        Destroy(gameObject);
    }
}
