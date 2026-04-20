using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
    public static int score = 0;
    public static string playerName = ""; 

    public static void SaveScore(string playerName)
    {
        List<(string name, int score)> scores = GetScores();
        scores.Add((playerName, score));

        // sort highest to lowest
        scores.Sort((a, b) => b.score.CompareTo(a.score));

        // keep only top 10
        if (scores.Count > 10) scores.RemoveRange(10, scores.Count - 10);

        PlayerPrefs.SetInt("ScoreCount", scores.Count);
        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score " + i, scores[i].score);
            PlayerPrefs.SetString("Name " + i, scores[i].name);
        }
        PlayerPrefs.Save();
    }

    public static List<(string name, int score)> GetScores()
    {
        List<(string, int)> scores = new List<(string, int)>();
        int count = PlayerPrefs.GetInt("ScoreCount", 0);
        for (int i = 0; i < count; i++)
            scores.Add((PlayerPrefs.GetString("Name " + i, "Unknown"),
                        PlayerPrefs.GetInt("Score " + i, 0)));
        return scores;
    }
}