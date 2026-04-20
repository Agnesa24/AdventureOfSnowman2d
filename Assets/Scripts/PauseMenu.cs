using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInput;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                ResumeButton();
            }
            else
            {
                PauseButton();
            }
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameData.score;
        }
    }

    public void PauseButton()
    {
        container.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1f;
    }

    public void NewGameButton()
    {
        GameData.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void EnterNameButton()
    {
        GameData.playerName = nameInput.text;
        string playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        GameData.SaveScore(playerName);
    }

    public void HighScoreButton()
    {
        // Save score BEFORE switching scenes
        if (nameInput != null && !string.IsNullOrWhiteSpace(nameInput.text))
        {
            GameData.playerName = nameInput.text;
            GameData.SaveScore(GameData.playerName);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("HighScoreScene");
    }

}
