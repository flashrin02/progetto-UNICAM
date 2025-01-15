using UnityEngine;
using TMPro;

public class EnergyCollector : MonoBehaviour
{
    private int energyParticle = 0;
    private bool nearWall = false; // Flag per indicare se il giocatore è vicino al muro

    public TextMeshProUGUI energyText; // Riferimento al testo della UI
    public TextMeshProUGUI actionText; // Riferimento al testo per l'azione (Premi F)
    public GameObject wall; // Riferimento al muro che vuoi far sparire

    private void Start()
    {
        actionText.gameObject.SetActive(false); // Nascondi il testo "Premi F" all'inizio
    }

    private void Update()
    {
        // Controlla se viene premuto il tasto F e se hai almeno 100 di energia
        if (Input.GetKeyDown(KeyCode.F) && nearWall && energyParticle >= 1)
        {
            Destroy(wall); // Distrugge il muro
            energyParticle = 0; // Riduci l'energia di 100
            UpdateEnergyText(); // Aggiorna il testo della UI
            actionText.gameObject.SetActive(false); // Nascondi il testo dopo la distruzione del muro
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("energy"))
        {
            energyParticle++;
            UpdateEnergyText(); // Aggiorna il testo ogni volta che raccogli energia
            Destroy(other.gameObject);
        }

        if (other.CompareTag("wall"))
        {
            nearWall = true; // Il giocatore è vicino al muro
            actionText.gameObject.SetActive(true); // Mostra il testo "Premi F"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            nearWall = false; // Il giocatore non è più vicino al muro
            actionText.gameObject.SetActive(false); // Nascondi il testo "Premi F"
        }
    }

    private void UpdateEnergyText()
    {
        energyText.text = "Energy: " + energyParticle + "/100"; // Aggiorna il testo della UI
    }
}
