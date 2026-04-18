using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        Time.timeScale = 1f;
        List<(string name, int score)> scores = GameData.GetScores();

        if (scores.Count == 0)
        {
            highScoreText.text = "No scores yet!";
            return;
        }

        string display = "High scores\n\n";
        for (int i = 0; i < scores.Count; i++)
            display += $"{i + 1}. {scores[i]}\n";

        highScoreText.text = display;
    }
}