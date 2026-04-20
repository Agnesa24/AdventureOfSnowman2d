using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void EnterNameButton()
    {
        string playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
    }

    public void HighScoreButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HighScoreScene");
    }

}
