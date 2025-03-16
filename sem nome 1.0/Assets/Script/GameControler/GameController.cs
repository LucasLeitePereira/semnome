using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Guarda as variaveis de texto que estão presentes na tela e faz a contagem de tempo
public class GameController : MonoBehaviour
{
    public static GameController gc;

    public TextMeshProUGUI timeText;
    public float timeCount;
    
    public bool timeOver;

    public TextMeshProUGUI itensText;
    public int itens;

    public TextMeshProUGUI vidaText;
    public int vidas = 2;
    public bool alive = true;

    private float pontos = 0;
    float timeTotal;
    private void Awake()
    {
        if (gc == null)
        {
            gc = this;
        }
        timeTotal = timeCount;
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

    private void TimeCount() // Contador de tempo
    {
        timeOver = false;

        if (!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            RefreshScreen();

            if (timeCount <= 0) // Jogador perde quanto o tempo termina
            {
                timeCount = 0;
                timeOver = true;

            }
        }
    }

    public void CalculoPts()
    {
        float tempo = timeCount;
        float resultado = ((-1500 * tempo) / timeTotal) + 1500;
        Debug.Log("Resultado " + resultado);

    }

}