using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gc;

    public TextMeshProUGUI timeText;
    public float timeCount;
    public bool timeOver;

    public TextMeshProUGUI itensText;
    public int itens;

    public TextMeshProUGUI vidaText;
    public int vidas = 3;

    private void Awake()
    {
        if(gc == null)
        {
            gc = this;
        }
        else if (gc != this) {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        TimeCount();
    }
    public void RefreshScreen()
    {
        vidaText.text = vidas.ToString();
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


