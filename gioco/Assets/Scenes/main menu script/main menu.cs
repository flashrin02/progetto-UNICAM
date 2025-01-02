using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    private bool OptionsShowing = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Controlla se ESC è stato premuto
        {
            if(OptionsShowing=true){
                OptionsHide();
            }
        }
    }
    public GameObject optionmenu; // Assegna il Canvas del menu di pausa
    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

     public void QuitGame(){
        Application.Quit();
    }

    public void OptionsShow(){
        optionmenu.SetActive(true); // Mostra il menu
        OptionsShowing=true;
    }

    public void OptionsHide(){
        optionmenu.SetActive(false); // Mostra il menu
        OptionsShowing=false;
    }

}
