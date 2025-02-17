using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorchManager : MonoBehaviour
{
    public GameObject[] torches;
    int index = 0;  //Tiene traccia della torcia da accendere
    public GameObject fragment;

    public void LightTorch(GameObject torch)
    {
        //Controlla se la torcia accesa è quella giusta
        if(index < torches.Length && torch == torches[index]){
            index++;

            //Se tutte le torce sono state accese nell'ordine giusto
            if (index >= torches.Length)
            {
                Debug.Log("Tutte le torce accese nell'ordine giusto!");
                fragment.SetActive(true);
            }
        } else {
            Debug.Log("Torcia sbagliata");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
