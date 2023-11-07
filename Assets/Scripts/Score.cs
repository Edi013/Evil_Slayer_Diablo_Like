using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text cronos;

    private int score;
    private float startTime;

    void Start()
    {
        score = 0;
        startTime = Time.time;

        UpdateScore(score);
        DisplayTime();
    }

    void Update()
    {
        DisplayTime();
        UpdateScore(score);
    }

    public void IncrementScore()
    {
        Debug.Log("am intrat in increment score");
        score++;
        Debug.Log("log2");
        UpdateScore(score);
        Debug.Log("log3");
    }

    private void UpdateScore(int score)
    {
        scoreText.text = String.Concat(score.ToString(), " KILLS");
    }

    private void DisplayTime()
    {
        float timePassed = Time.time - startTime ;
        int seconds = Mathf.FloorToInt(timePassed % 60f);
        int minutes = Mathf.FloorToInt(timePassed / 60f);

        cronos.text = String.Concat(minutes.ToString(), " m  ", seconds.ToString(), " s  ");
    }
}
