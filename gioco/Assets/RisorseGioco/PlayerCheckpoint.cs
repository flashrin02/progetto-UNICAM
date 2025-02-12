using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpoint;
    private bool hasCheckpoint = false;

    void Start()
    {
        // Salva la posizione iniziale come primo checkpoint
        lastCheckpoint = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        // Se il player tocca un checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = transform.position;
            hasCheckpoint = true;
            Debug.Log("Checkpoint salvato!");
        }
        // Se il player tocca la lava
        else if (other.CompareTag("Lava"))
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        // Teletrasporta il player all'ultimo checkpoint
        transform.position = lastCheckpoint;
        Debug.Log("Player respawnato all'ultimo checkpoint!");
        
        // Qui puoi aggiungere altri effetti di morte/respawn
        // Per esempio:
        // - Animazione di morte
        // - Suono
        // - Particelle
        // - Decremento vite
    }
}