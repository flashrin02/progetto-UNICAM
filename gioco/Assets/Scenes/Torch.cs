using UnityEngine;

public class Tourch : MonoBehaviour
{
    public GameObject fire;

    void Start(){
        fire.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        //Controlla se il player è entrato nell'area della torcia
        if(other.CompareTag("Player")){
            fire.SetActive(true);   //Accende il fuoco
        }
        Debug.Log("Il player è entrato nella torcia!");
    }
}
