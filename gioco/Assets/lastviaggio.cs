using UnityEngine;
using UnityEngine.SceneManagement; 
public class lastviaggio : MonoBehaviour
{
    //funzione per caricare la scena successiva quando l'oggetto con il seguente codice viene abilitato
    void OnEnable()
    {
    SceneManager.LoadScene(9);
    }
}
