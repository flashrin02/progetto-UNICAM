using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SkipCutScene : MonoBehaviour
{
    public PlayableDirector timeline; // La Timeline da controllare
    public string nextSceneName; // Nome della scena successiva

    public void Skip()
    {
        if (timeline != null)
        {
            timeline.Stop(); // Ferma la Timeline
        }

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName); // Carica la scena successiva
        }
    }
}
