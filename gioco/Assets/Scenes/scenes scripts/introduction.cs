using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.SceneManagement;
public class introduction : MonoBehaviour
{
    void OnEnable()
    {
    SceneManager.LoadScene(2);
    }
}