using System;
using UnityEngine;
using UnityEngine.UI;

public class Cronos : MonoBehaviour
{
    public Text cronos;

    private float startTime;
    private bool isOn = true;

    void Start()
    {
        startTime = Time.time;
        isOn = true;
    }

    void Update()
    {
        if (isOn)
        {
            DisplayTime();
        }
    }

    private void DisplayTime()
    {
        float timePassed = Time.time - startTime;
        int seconds = Mathf.FloorToInt(timePassed % 60f);
        int minutes = Mathf.FloorToInt(timePassed / 60f);

        cronos.text = String.Concat(minutes.ToString(), " m  ", seconds.ToString(), " s  ");
    }
    public void StopCounter()
    {
        isOn = false;
    }
}
