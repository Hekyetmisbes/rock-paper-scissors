using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Restart the game
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    // Play the game
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
