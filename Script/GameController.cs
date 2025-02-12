using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timeText;
    public float timeCount = 211f; // 3:31 minutos = 211 segundos (COLOQUEI 1 SEG A MAIS PARA NAO DESCER MUITO RAPIDO DO 3:30 PARA 3:29)
    private bool timeOver = false;

    private void Update()
    {
        if (!timeOver)
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                timeCount = 0;
                timeOver = true;
                // Chama a função de perder vida ou outra ação quando o tempo acabar
               // GameObject.Find("Player").GetComponent<PlayerLife()>.LoseLife();
            }

            RefreshScreen();
        }
    }

    // Atualiza a tela com o tempo formatado (minutos:segundos)
    public void RefreshScreen()
    {
        int minutes = Mathf.FloorToInt(timeCount / 60);  // Calcula os minutos
        int seconds = Mathf.FloorToInt(timeCount % 60);  // Calcula os segundos restantes

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
