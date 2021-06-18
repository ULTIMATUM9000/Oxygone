using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    float score;
    float highscore = 0;
    public Text scoreText;
    public Text highScoreText;
    
    private void Start()
    {
        score = PlayerPrefs.GetFloat("CurrentScore");
        highscore = PlayerPrefs.GetFloat("HighScore");
        scoreText.text = "TREES RESTORED: " + score.ToString("000");
        highScoreText.text = "HIGH SCORE: " + highscore.ToString("000");
    }
    public void AddScore(float value)
    {
        score += value;
        PlayerPrefs.SetFloat("CurrentScore", score);
        SetHighScore();
        scoreText.text = "TREES RESTORED: " + score.ToString("000");
    }
    public void SetHighScore()
    {
        if(highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetFloat("HighScore", highscore);
            highScoreText.text = "HIGH SCORE: " + highscore.ToString("000");
        }
    }
}
