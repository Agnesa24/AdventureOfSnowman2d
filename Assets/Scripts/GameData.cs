using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
    public static int score = 0;

    public static void SaveScore()
    {
        // Load existing scores
        List<int> scores = GetScores();
        scores.Add(score);

        // Sort highest to lowest
        scores.Sort((a, b) => b.CompareTo(a));

        // Keep only top 10
        if (scores.Count > 10) scores.RemoveRange(10, scores.Count - 10);

        // Save count and each score
        PlayerPrefs.SetInt("ScoreCount", scores.Count);
        for (int i = 0; i < scores.Count; i++)
            PlayerPrefs.SetInt("Score_" + i, scores[i]);

        PlayerPrefs.Save();
    }

    public static List<int> GetScores()
    {
        List<int> scores = new List<int>();
        int count = PlayerPrefs.GetInt("ScoreCount", 0);
        for (int i = 0; i < count; i++)
            scores.Add(PlayerPrefs.GetInt("Score_" + i, 0));
        return scores;
    }
}