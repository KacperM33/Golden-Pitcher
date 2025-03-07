using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] Text text;
    public int currentCoins;

    private void Start()
    {
        currentCoins = 0;
    }

    private void Update()
    {
        text.text = currentCoins.ToString();
    }

    // Metoda zwiêkszaj¹ca liczbê z³otych dzbanów
    public void IncrementCoins()
    {
        currentCoins += 1;
    }
}
