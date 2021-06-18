using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    float score;
    float highscore;
    float timerScore;
    public Text scoreText;
    public Text highScoreText;
    public Text timerScoreText;

    private void Start()
    {
        score = PlayerPrefs.GetFloat("CurrentScore");
        highscore = PlayerPrefs.GetFloat("HighScore");
        timerScore = PlayerPrefs.GetFloat("Timer");
        scoreText.text = "TREES RESTORED: " + score.ToString("000");
        highScoreText.text = "HIGH SCORE: " + highscore.ToString("000");
        timerScoreText.text = "TIME SURVIVED: " + timerScore.ToString("000");
    }
}
