using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDePontos : MonoBehaviour
{
    public static ContadorDePontos cp;
    public GameController game;  // Script de tempo

    void Start()
    {
        Debug.Log("Jogo Iniciado");
        game = GameController.gc;

        if (cp == null )
        {
            cp = this;
        }
    }

    // Update is called once per frame

    public void calcularPts()
    {
        float tempo = game.timeCount;
        float resultado = ((50 * tempo)/ 3);
        Debug.Log(resultado);
    }

}
