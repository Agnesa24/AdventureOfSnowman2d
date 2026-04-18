using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject container;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInput;
    public string playerName;
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
        Debug.Log("SavedGameButton called"); // check Console for this
        container.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ExitButton()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }

    public void EnterNameButton()
    {
        playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        Debug.Log("Player name saved: " + playerName);
    }

    public void HighScoreButton()
    {
        SceneManager.LoadScene("HighScoreScene");
        Time.timeScale = 0f;

    }

    public void PauseButton()
    {
        container.SetActive(true); // Show the pause menu by activating the container GameObject
        if(Time.timeScale != 0f) {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
            // Pause the game by setting timeScale to 0
    }
}
