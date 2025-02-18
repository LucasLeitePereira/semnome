using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float timeCount;
    public bool timeOver;


    private void Update()
    {
        TimeCount();
    }
    public void RefreshScreen()
    {
        timeText.text = timeCount.ToString("F0");
    }

    void TimeCount()
    {
        timeOver = false;

        if (!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            RefreshScreen();

            if (timeCount <= 0)
            {
                timeCount = 0;
                timeOver = true;
                Time.timeScale = 0;
            }
        }
    }
}


