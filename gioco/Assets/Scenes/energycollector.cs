using UnityEngine;
using TMPro;

public class EnergyCollector : MonoBehaviour
{
    private int energyParticle = 0;
    private bool nearWall = false; // Flag per indicare se il giocatore è vicino al muro

    public TextMeshProUGUI energyText; // Riferimento al testo dell' energia
    public TextMeshProUGUI actionText; // Riferimento al testo (Premi F)
    public GameObject wall; // Riferimento al muro da far sparire

    private void Start()
    {
        actionText.gameObject.SetActive(false); // Nascondo il testo "Premi F" all'inizio
    }

    private void Update()
    {
        // Controllo se viene premuto il tasto F e se ho almeno tot di energia
        if (Input.GetKeyDown(KeyCode.F) && nearWall && energyParticle >= 1)
        {
            Destroy(wall); // Distruggo il muro
            energyParticle = 0; // Riduco l'energia 
            UpdateEnergyText(); // Aggiorno il testo della UI
            actionText.gameObject.SetActive(false); // Nascondo il testo dopo la distruzione del muro
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("energy"))
        {
            energyParticle++;
            UpdateEnergyText(); // Aggiorno il testo ogni volta che raccogli energia
            Destroy(other.gameObject);
        }

        if (other.CompareTag("wall"))
        {
            nearWall = true; // Il giocatore è vicino al muro
            actionText.gameObject.SetActive(true); // Mostro il testo "Premi F"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            nearWall = false; // Il giocatore non è più vicino al muro
            actionText.gameObject.SetActive(false); // Nascondo il testo "Premi F"
        }
    }

    private void UpdateEnergyText()
    {
        energyText.text = "Energy: " + energyParticle + "/100"; // Aggiorno il testo della UI
    }
}
