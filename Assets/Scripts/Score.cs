using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private int score;

    void Start()
    {
        score = 0;

        UpdateScore(score);
    }

    public void IncrementScore()
    {
        score++;
        UpdateScore(score);
    }

    private void UpdateScore(int score)
    {
        scoreText.text = String.Concat(score.ToString(), " KILLS");
    }
}
