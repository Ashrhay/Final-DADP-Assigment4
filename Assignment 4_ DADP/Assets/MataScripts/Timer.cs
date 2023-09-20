using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private TimeSpan timeSpan;

    private bool isTimerRunning;

    private DateTime startTime;

    private readonly TimeSpan targetTime = new TimeSpan(0, 15, 0);

    private void Start()
    {

        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {

            timeSpan = DateTime.Now - startTime;


            if (timeSpan >= targetTime)
            {
                StopTimer();
                timeSpan = targetTime;
            }


            UpdateTimerText();
        }
    }

    public void StartTimer()
    {

        startTime = DateTime.Now;


        isTimerRunning = true;
    }

    public void StopTimer()
    {

        isTimerRunning = false;
    }

    public void ResetTimer()
    {

        startTime = DateTime.Now;
    }

    private void UpdateTimerText()
    {

        string formattedTime = string.Format("{0:D2}:{1:D2}",
            timeSpan.Minutes, timeSpan.Seconds);


        timerText.text = formattedTime;
    }
}