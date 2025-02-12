using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class TimelineSkipper : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private string nextSceneName;

    public void SkipTimelineAndLoadNextScene()
    {
        // Ferma la timeline
        if (timeline != null)
        {
            timeline.Stop();
        }

        // Carica la scena successiva
        SceneManager.LoadScene(nextSceneName);
    }
}