using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class PlayButton : MonoBehaviour
{
    // Function to load the game scene
    public void PlayGame()
    {
        // Replace "GameScene" with the name of your game scene
        SceneManager.LoadScene("GameScene");
    }
}
