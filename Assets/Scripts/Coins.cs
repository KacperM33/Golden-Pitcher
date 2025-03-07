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

    // Metoda zwi�kszaj�ca liczb� z�otych dzban�w
    public void IncrementCoins()
    {
        currentCoins += 1;
    }
}
