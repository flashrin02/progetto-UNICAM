using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Aggiungi per UI4
using TMPro;



public class ObjectCollector : MonoBehaviour
{
    public float pickupDistance = 3.0f;  // Distanza per raccogliere l'oggetto
    public string message = "Premi F per raccogliere l'oggetto";  // Messaggio UI
    public TMP_Text messageText;  // Riferimento al componente Text UI
    private bool canCollect = false;
    private bool collected = false;

    void Start()
    {
        // Assicurati che il messaggio sia nascosto all'inizio
        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    void Update()
{
    // Controllo della distanza
    if (!collected && Vector3.Distance(transform.position, Camera.main.transform.position) <= pickupDistance)
    {
        // Mostra il messaggio
        DisplayMessage(message);

        // Se il giocatore preme "F", raccogli l'oggetto
        if (Input.GetKeyDown(KeyCode.F))
        {
            CollectObject();
        }
    }
    else
    {
        // Se lontano dall'oggetto, nascondi il messaggio
        HideMessage();
    }

    // Debug: verifica che il tasto "E" venga rilevato
    if (collected && Input.GetKeyDown(KeyCode.E))
    {
        Debug.Log("Tasto E premuto! Caricamento della scena...");
        LoadNewScene();
    }
}


    void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }

    void HideMessage()
    {
        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    void CollectObject()
    {
        collected = true;
        // Nascondi l'oggetto visibile (per esempio, disattivando il GameObject)
        gameObject.SetActive(false);
        // Puoi anche aggiungere effetti visivi o sonori qui
    }

    void LoadNewScene()
    {
        // Carica la scena successiva
        SceneManager.LoadScene(6);  // Sostituisci con il nome della scena
    }
}
