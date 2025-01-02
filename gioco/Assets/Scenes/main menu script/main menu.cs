using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject optionmenu; // Assegna il Canvas del menu di pausa
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

     public void QuitGame(){
        Application.Quit();
    }

    public void OptionsShow(){
        optionmenu.SetActive(true); // Mostra il menu
    }

    public void OptionsHide(){
        optionmenu.SetActive(false); // Mostra il menu
    }

}
