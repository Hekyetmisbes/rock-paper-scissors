using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
