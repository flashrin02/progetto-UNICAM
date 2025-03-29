using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class LetterChallenge : MonoBehaviour
{
    public TextMeshProUGUI letterText; // UI per mostrare la lettera
    public TextMeshProUGUI scoreText;  // UI per il punteggio
    public Collider targetPlane; // Piano specifico
    public GameObject GameObject; 
    public float timeLimit = 3f; // Tempo limite per premere il tasto

    private string targetLetter;  
    private bool isActive = false;
    private float timer;
    private int score = 0; // Punteggio

    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Debug.Log("Tempo scaduto!");
                RestartLevel();
            }

            // Controlla se il player preme un tasto
            if (Input.anyKeyDown)
            {
                if (Input.inputString == targetLetter.ToLower())
                {
                    score++;
                    UpdateScoreText();
                    DisplayRandomLetter();
                    timer = timeLimit; // Reset timer

                    // Controlla se il giocatore ha raggiunto 100 punti
                    if (score >= 100)
                    {
                        TriggerFall();
                    }
                }
                else
                {
                    Debug.Log("Lettera sbagliata!");
                    score = 0;
                    UpdateScoreText();
                    RestartLevel();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == targetPlane)
        {
            StartChallenge();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider == targetPlane)
        {
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
        letterText.text = "";
    }

    private void DisplayRandomLetter()
    {
        char randomLetter = (char)Random.Range('A', 'Z' + 1);
        targetLetter = randomLetter.ToString();
        letterText.text = targetLetter;
        timer = timeLimit;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void TriggerFall()
    {
        // Imposta il piano come trigger, facendo "cadere" il giocatore
        targetPlane.isTrigger = true;
        isActive = false;

        // Rende visibile l'oggetto
        if (GameObject != null)
        {
            GameObject.SetActive(true); 
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
