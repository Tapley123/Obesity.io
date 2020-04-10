using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerTest;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    
    public void UpdateTimerTest()
    {
        secondsCount += Time.deltaTime;
        timerTest.text = "Time: " + hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    void Update()
    {
        UpdateTimerTest();
    }
}
