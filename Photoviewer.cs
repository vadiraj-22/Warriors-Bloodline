using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Photoviewer : MonoBehaviour
{
    public Image photoDisplay; // Reference for displaying photos
    public Button playButton;  // Play button reference
    public Button nextButton;  // Next button reference
    public Sprite[] photos;    // Array of photo sprites

    private int currentPhotoIndex = 0; // To track which photo is displayed

    void Start()
    {
        // Set up button listeners
        playButton.onClick.AddListener(StartPhotoSequence);
        nextButton.onClick.AddListener(ShowNextPhoto);

        // Initially hide the Next button
        nextButton.gameObject.SetActive(false);
    }

    void StartPhotoSequence()
    {
        if (photos.Length > 0)
        {
            photoDisplay.sprite = photos[0]; // Display the first photo
            currentPhotoIndex = 0;

            // Hide the Play button and show the Next button
            playButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
    }

    void ShowNextPhoto()
    {
        currentPhotoIndex++;

        if (currentPhotoIndex < photos.Length)
        {
            // Display the next photo
            photoDisplay.sprite = photos[currentPhotoIndex];
        }
        else
        {
            // All photos are displayed, transition to the game
            StartGame();
        }
    }

    void StartGame()
    {
        Debug.Log("Starting the game...");
       SceneManager.LoadScene("SampleScene");
    // Replace "GameScene" with your game's scene name
    }
}