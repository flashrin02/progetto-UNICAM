using UnityEngine;

public class Tourch : MonoBehaviour
{
    public GameObject fire;
    bool isLit = false;     //Indica se la torcia è accesa
    TorchManager manager;

    void Start()
    {
        //Trova il TorchManager nella scena
        manager = FindObjectOfType<TorchManager>();    
    }

    void OnTriggerEnter(Collider other)
    {
        //Controlla se il player è entrato nell'area della torcia
        if(!isLit && other.CompareTag("Player")){
            Transform light = fire.transform.Find("Light");
            light.gameObject.SetActive(true);
            isLit = true;
            manager.LightTorch(gameObject);     //Comunica al manager l'accensione
        }
    }
}
