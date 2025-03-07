using UnityEngine;

public class CoinsController : MonoBehaviour, Interactable
{
    private Coins coins;

    // Metoda dziedziczona z interfejsu Interactable, tutaj odpowiedzialna za zbieranie z�otych dzban�w
    public void Interact()
    {
        if (coins == null)
        {
            coins = Object.FindFirstObjectByType<Coins>();
        }

        // Wywo�anie metody zwi�kszaj�cej liczb� zebranych z�otych dzban�w i zniszczenie podniesionego z�otego dzbana
        coins.IncrementCoins();
        Destroy(gameObject);
    }
}
