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
        gameObject.SetActive(false); // Nasconde l'oggetto
    }

    void LoadNewScene()
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("⚠ ERRORE: La scena '" + sceneName + "' non esiste nei Build Settings!");
        }
    }

}
