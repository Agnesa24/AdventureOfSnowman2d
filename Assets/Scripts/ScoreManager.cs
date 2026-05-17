using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

    public void SubtractScore()
    {
        GameData.score = GameData.score - 3;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + GameData.score;
    }
}