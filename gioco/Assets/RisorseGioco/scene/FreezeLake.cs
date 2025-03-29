using UnityEngine;
using TMPro; // Aggiungi questa direttiva per TextMeshPro
using UnityEngine.SceneManagement;

public class LetterChallenge : MonoBehaviour
{
    public TextMeshProUGUI letterText; // TextMeshProUGUI per mostrare la lettera
    public float timeLimit = 3f; // Limite di tempo per premere la lettera
    private string targetLetter;
    private bool isActive = false;
    private float timer;

    // Piano specifico su cui il player deve camminare
    public Collider targetPlane;

    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // Se il tempo è scaduto, riavvia il livello
                RestartLevel();
            }
        }

        // Controlla se una lettera è stata premuta
        if (Input.anyKeyDown && isActive)
        {
            if (Input.inputString == targetLetter.ToLower()) // Verifica che la lettera premuta sia corretta
            {
                DisplayRandomLetter(); // Mostra una nuova lettera
                timer = timeLimit; // Reset del timer
            }
            else
            {
                RestartLevel(); // Se la lettera è sbagliata, riavvia il livello
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == targetPlane)
        {
            // Attiva il challenge quando il player cammina sul piano specifico
            StartChallenge();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == targetPlane)
        {
            // Disattiva il challenge quando il player esce dal piano
            StopChallenge();
        }
    }

    private void StartChallenge()
    {
        isActive = true;
        timer = timeLimit;
        DisplayRandomLetter();
    }

    private void StopChallenge()
    {
        isActive = false;
        letterText.text = ""; // Rimuove la lettera dallo schermo
    }

    private void DisplayRandomLetter()
    {
        // Scegli una lettera casuale
        char randomLetter = (char)Random.Range('A', 'Z' + 1);
        targetLetter = randomLetter.ToString();

        // Mostra la lettera sullo schermo
        letterText.text = targetLetter;

        // Imposta il timer per il limite di tempo
        timer = timeLimit;
    }

    private void RestartLevel()
    {
        // Riavvia il livello corrente
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
