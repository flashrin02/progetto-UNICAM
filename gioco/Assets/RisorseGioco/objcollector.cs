using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Per UI

public class ObjectCollector : MonoBehaviour
{
    public float pickupDistance = 3.0f;  // Distanza per raccogliere l'oggetto
    public string message = "Premi F per raccogliere l'oggetto";  // Messaggio UI
    public TMP_Text messageText;  // Riferimento a TextMeshPro
    public string sceneName = "Spacetravel"; // Nome della scena da caricare

    private bool collected = false;
    private GameObject player;  // Riferimento al giocatore

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("⚠ Errore: Nessun oggetto con il tag 'Player' trovato!");
        }

        if (messageText != null)
        {
            messageText.text = "";
        }
        else
        {
            Debug.LogError("⚠ Errore: Il riferimento a TMP_Text non è assegnato!");
        }
    }

    void Update()
    {
        if (player == null) return;  

        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("🔍 Distanza giocatore-oggetto: " + distance);

        if (!collected && distance <= pickupDistance)
        {
            DisplayMessage(message);

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("✅ Tasto F premuto: raccolgo l'oggetto.");
                CollectObject();
            }
        }
        else
        {
            HideMessage();
        }

        if (collected)
        {
            Debug.Log("📦 Oggetto raccolto. Aspettando il tasto E...");

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("✅ Tasto E premuto! Tentativo di caricare la scena...");
                LoadNewScene();
            }
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
        gameObject.SetActive(false); // Nasconde l'oggetto
    }

    void LoadNewScene()
    {
        Debug.Log("🚀 Caricamento scena: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
