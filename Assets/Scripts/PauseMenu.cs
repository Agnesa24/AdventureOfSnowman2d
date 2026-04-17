using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject container;
    public static int score = 0;
    public TMPro.TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // Check if the Escape key is pressed
        {
            container.SetActive(true); // Show the pause menu by activating the container GameObject
            Time.timeScale = 0f; // Pause the game by setting timeScale to 0
        }
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    /*public void ResumeButton()
    {
        container.SetActive(false); // Hide the pause menu by deactivating the container GameObject
        Time.timeScale = 1f; // Resume the game by setting timeScale back to 1
    }
    */
    public void NewGameButton()
    {
        SceneManager.LoadScene("SampleScene"); // Reload the current scene to start a new game
    }

    public void SavedGameButton()
    {
        container.SetActive(false); // Hide the pause menu by deactivating the container GameObject
        Time.timeScale = 1f; // Resume the game by setting timeScale back to 1
    }
    public void ExitButton() //visual studio itself gave me this code 
    {
        Application.Quit(); // Quit the application when the Exit button is clicked
    }

    public void EnterNameButton()
    {

    }

    public void HighScoreButton()
    {
        SceneManager.LoadScene("HighScores");

    }
}
