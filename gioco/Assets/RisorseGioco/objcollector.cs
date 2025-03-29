using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    public float pickupDistance = 3.0f;  // Distanza per raccogliere l'oggetto
    public GameObject premif;  // Riferimento all'oggetto UI (TextMeshPro nel Canvas)
    public string sceneName; // Nome della scena da caricare

    private bool collected = false;
    private GameObject player;  // Riferimento al giocatore

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("⚠ Errore: Nessun oggetto con il tag 'Player' trovato!");
        }

        if (premif != null)
        {
            premif.SetActive(false); // Assicuriamoci che parta nascosto
        }
        else
        {
            Debug.LogError("⚠ Errore: Il riferimento a 'premif' non è assegnato!");
        }
    }

    void Update()
    {
        if (player == null) return;  

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (!collected && distance <= pickupDistance)
        {
            premif.SetActive(true); // Mostra "Premi F"

            if (Input.GetKeyDown(KeyCode.F))
            {
                CollectObject();
            }
        }
        else
        {
            premif.SetActive(false); // Nasconde "Premi F"
        }

        if (collected)
        {
            LoadNewScene();
        }
    }

    void CollectObject()
    {
        collected = true;
        premif.SetActive(false); // Nasconde il testo dopo la raccolta
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
