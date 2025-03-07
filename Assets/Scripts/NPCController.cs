using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    // Metoda dziedziczona z interfejsu Interactable, odpowiada za interakcje z elementem gry
    public void Interact()
    {
        // Wywo³anie dialogu dla NPC
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
