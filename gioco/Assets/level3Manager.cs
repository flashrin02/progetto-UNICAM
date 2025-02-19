using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Level3Manager : MonoBehaviour
{
    public GameObject iceStepPrefab; // Prefab degli scalini di ghiaccio
    public Transform player; // Riferimento al personaggio
    public Text letterText; // UI per mostrare la lettera
    public Text energyText; // UI per mostrare l'energia
    public GameObject frozenLake; // Il lago ghiacciato che si attiva alla fine
    public GameObject fragment; // Il frammento da raccogliere
    public float stepDistance = 1.5f; // Distanza tra gli scalini
    public int playerEnergy = 100; // Energia iniziale
    private char currentLetter;
    private bool gameOver = false;

    void Start()
    {
        GenerateNewLetter();
        UpdateEnergyUI();
    }

    void Update()
    {
        if (gameOver) return;

        if (Input.anyKeyDown)
        {
            string input = Input.inputString.ToUpper();
            if (input.Length == 1 && input[0] == currentLetter)
            {
                CreateIceStep();
                GenerateNewLetter();
            }
            else
            {
                playerEnergy -= 10; // Penalità se sbaglia
                UpdateEnergyUI();
                if (playerEnergy <= 0)
                {
                    RestartLevel();
                }
            }
        }
    }

    void GenerateNewLetter()
    {
        currentLetter = (char)Random.Range(65, 91); // Genera una lettera A-Z
        letterText.text = "Premi: " + currentLetter;
    }

    void CreateIceStep()
    {
        Vector3 newStepPos = new Vector3(player.position.x, player.position.y - stepDistance, player.position.z);
        Instantiate(iceStepPrefab, newStepPos, Quaternion.identity);
        player.position = newStepPos; // Il personaggio scende

        // Controlla se è arrivato in fondo
        if (player.position.y <= -10f) // Soglia per il fondo del lago
        {
            FreezeLake();
        }
    }

    void FreezeLake()
    {
        frozenLake.SetActive(true); // Mostra il lago ghiacciato
        fragment.SetActive(true); // Rende il frammento visibile
        letterText.text = "Cerca il frammento!";
        gameOver = true;
    }

    void UpdateEnergyUI()
    {
        energyText.text = "Energia: " + playerEnergy;
    }

    void RestartLevel()
    {
        gameOver = true;
        letterText.text = "Hai perso! Riprova.";
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
