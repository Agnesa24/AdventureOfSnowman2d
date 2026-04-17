using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void AddScore()
    {
        GameData.score++;
        scoreText.text = "Score: " + GameData.score.ToString();
    }
}
