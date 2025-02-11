using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 lastCheckpoint; // Ultimo checkpoint salvato

    private void Start()
    {
        lastCheckpoint = transform.position; // Posizione iniziale
        Debug.Log("Posizione iniziale del giocatore: " + lastCheckpoint); // Aggiunto per debug
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition; // Salva la posizione del checkpoint
        Debug.Log("Checkpoint salvato: " + lastCheckpoint); // Verifica che il checkpoint sia stato salvato
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava")) // Se il giocatore tocca la lava
        {
            Debug.Log("Il giocatore è morto! Respawn al checkpoint.");
            Respawn(); // Respawn al checkpoint
        }
    }

    private void Respawn()
    {
        transform.position = lastCheckpoint; // Riporta il giocatore all'ultimo checkpoint
        Debug.Log("Respawn alla posizione: " + lastCheckpoint); // Verifica che il giocatore respawni al checkpoint giusto
    }
}
