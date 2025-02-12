using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Se il giocatore tocca il checkpoint
        {
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>(); // Ottieni il componente PlayerRespawn

            if (playerRespawn != null)
            {
                Debug.Log("Checkpoint toccato!"); // Debug per confermare che il checkpoint è stato toccato
                playerRespawn.SetCheckpoint(transform.position); // Salva la posizione del checkpoint
            }
            else
            {
                Debug.LogError("Il giocatore non ha lo script 'PlayerRespawn'!"); // Se non trova PlayerRespawn
            }
        }
    }
}
