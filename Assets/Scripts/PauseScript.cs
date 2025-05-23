using Unity.VisualScripting;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject ControlsPanel;
    public GameObject ControlsPanel2;
    public GameObject StartPanel;

    private bool isPaused = false;
    private bool isControl = false;

    public void Start()
    {
        Time.timeScale = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Metoda odpowiedzialna za zatrzymanie gry
    public void Pause()
    {   
        isPaused = true;
        PausePanel.SetActive(true);
        ControlsPanel.SetActive(false);
        Time.timeScale = 0;
    }

    // Metoda odpowiedzialna za wznowienie gry
    public void Resume()
    {   
        isPaused = false;
        PausePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Metoda odpowiedzialna za wyłączenie gry
    public void Quit()
    {
        Application.Quit();
    }

    // Metoda odpowiedzialna za wyświetlenie panelu sterowania
    public void Controls()
    {
        PausePanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    // Metoda odpowiedzialna za rozpoczęcie gry
    public void StartGame()
    {
        Time.timeScale = 1;
        Destroy(StartPanel);
    }

    // Metoda odpowiedzialna za wyświetlenie alternatywnego panelu sterowania
    public void Controls2on()
    {
        ControlsPanel2.SetActive(true);
        StartPanel.SetActive(false);
    }

    // Metoda wyłączająca alternatywny panel sterowania
    public void Controls2off()
    {
        ControlsPanel2.SetActive(false);
        StartPanel.SetActive(true);
    }
}
