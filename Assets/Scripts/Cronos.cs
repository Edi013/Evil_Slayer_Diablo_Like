using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronos : MonoBehaviour
{
    public Text cronos;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        DisplayTime();
    }

    private void DisplayTime()
    {
        float timePassed = Time.time - startTime;
        int seconds = Mathf.FloorToInt(timePassed % 60f);
        int minutes = Mathf.FloorToInt(timePassed / 60f);

        cronos.text = String.Concat(minutes.ToString(), " m  ", seconds.ToString(), " s  ");
    }
}
