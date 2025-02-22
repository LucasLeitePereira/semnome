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
        if (gc == null)
        {
            gc = this;
        }
    }

    public void RefreshScreen()
    {
        vidaText.text = vidas.ToString();
        timeText.text = timeCount.ToString("F0");
    }

}