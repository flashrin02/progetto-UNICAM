using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // Assegna il Canvas del menu di pausa
     public GameObject optionmenu; // Assegna il Canvas del menu di pausa

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Controlla se ESC è stato premuto
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Mostra il menu
        Time.timeScale = 0f; // Ferma il tempo di gioco
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Nascondi il menu
        Time.timeScale = 1f; // Ripristina il tempo di gioco
        isPaused = false;
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }

     public void OptionsShow(){
        optionmenu.SetActive(true); // Mostra il menu
    }

    public void OptionsHide(){
        optionmenu.SetActive(false); // Mostra il menu
    }
}
