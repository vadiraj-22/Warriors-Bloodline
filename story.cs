using UnityEngine;
using UnityEngine.UI;

public class PhotoViewer : MonoBehaviour
{
    public Image photoDisplay; // Reference to the Image component to display photos
    public Button playButton;  // Reference to the Play button
    public Button nextButton;  // Reference to the Next button
    public Sprite[] photos;    // Array to store the photos

    private int currentPhotoIndex = 0; // Tracks the current photo index

    void Start()
    {
        // Initialize buttons
        playButton.onClick.AddListener(StartPhotoSequence);
        nextButton.onClick.AddListener(ShowNextPhoto);
        nextButton.gameObject.SetActive(false); // Hide the Next button initially
    }

    void StartPhotoSequence()
    {
        if (photos.Length > 0)
        {
            photoDisplay.sprite = photos[0]; // Show the first photo
            currentPhotoIndex = 0;
            playButton.gameObject.SetActive(false); // Hide the Play button
            nextButton.gameObject.SetActive(true);  // Show the Next button
        }
    }

    void ShowNextPhoto()
    {
        currentPhotoIndex++;
        if (currentPhotoIndex < photos.Length)
        {
            photoDisplay.sprite = photos[currentPhotoIndex]; // Show the next photo
        }
        else
        {
            // All photos have been shown, start the game
            StartGame();
        }
    }

    void StartGame()
    {
        Debug.Log("Starting the game!");
        // Transition to the game scene or enable game elements
        // Example: UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}