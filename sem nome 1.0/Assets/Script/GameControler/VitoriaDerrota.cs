using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VitoriaDerrota : MonoBehaviour
{
    public GameController game;  // Script de tempo
    public VidaScript vida;     // Script de vida
    public ColetaDeItem item;  // Script de coleta de item

    public string cenaMenu;

    public GameObject telaDerrota;
    public GameObject telaVitoria;
    
    private void Start()
    {
        game = GameController.gc;
        vida = VidaScript.vs;
        item = ColetaDeItem.ci;

        telaDerrota.SetActive(false); // Desliga a tela de Derrota
        telaVitoria.SetActive(false); // Desliga a tela de Vitoria

        Time.timeScale = 1; // Ao reiniciar, ele "liga" o tempo de novo
        game.alive = true;  // Ao reiniciar, ele reseta a quantidade de vidas
        
    }

    private void Update()
    {
        itWon(); // Ganhou a fase
        itLost(); // Perdeu a fase
    }

    private void itWon()
    {
        if (game.itens == item.qntTotalItens) // Jogador ganha ao coletar todos os itens da fase
        {
            Time.timeScale = 0;
            telaVitoria.SetActive(true);
            game.CalculoPts();
        }
    }

    private void itLost()
    {
        if (!game.alive || game.timeOver)
        {
            Time.timeScale = 0;
            telaDerrota.SetActive(true); // Liga a tela de derrota
            game.CalculoPts();
        }
        
    }

    public void voltarMenu() // Botão de Sair
    {
        Debug.Log("Mudando para tela de Menu");
        SceneManager.LoadScene(cenaMenu);
    }

    public void resetarFase() // Botão de reiniciar a fase
    {
        Debug.Log("Reiniciando a fase atual");
        SceneManager.LoadScene("Fase01");
    }
}
