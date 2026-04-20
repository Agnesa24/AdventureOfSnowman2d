using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        GameData.score = 0; // reset at start of game
        UpdateUI();
    }

    public void AddScore()
    {
        GameData.score++;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + GameData.score;
    }
}