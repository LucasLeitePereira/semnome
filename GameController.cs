using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timeText;
    public float timeCount;
    public bool timeOver = false;


    //FAZER VERFICACAO DE VIDA


    private void Update()
    {
        timeCount();
    }

    public void RefreshScreen()
    {
        timeText.text = timeCount.ToString("F0");
    }
    void timeCount ()
    {
        timeOver = false;
        if (!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            RefreshScreen();

            if(timeCount <=0)
            {
                timeCount = 0;
                GameObject.Find("Player").GetComponent < PlayerLife().LoseLife();
                timeOver = true;
            }
        }
    }
}
