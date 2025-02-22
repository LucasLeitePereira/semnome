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
        vida.alive = true;  // Ao reiniciar, ele reseta a quantidade de vidas
        
    }

    private void Update()
    {
        itWon(); // Ganhou a fase
        TimeCount(); // Perde se o tempo acabar
        isDead(); // Perde se perder todas as vidas
    }

    private void TimeCount() // Contador de tempo
    {
        game.timeOver = false;

        if (!game.timeOver && game.timeCount > 0)
        {
            game.timeCount -= Time.deltaTime;
            game.RefreshScreen();

            if (game.timeCount <= 0) // Jogador perde quanto o tempo termina
            {
                game.timeCount = 0;
                game.timeOver = true;
                itLost();
            }
        }
    }

    private void isDead() // Verifica se o jogar ainda está vivo
    {
        if (!vida.alive)
        {
            Debug.Log("Sem vidas restantes");
            itLost();

        }
    }

    private void itWon()
    {
        if (game.itens == item.qntTotalItens) // Jogador ganha ao coletar todos os itens da fase
        {
            Debug.Log("Ganhou!");
            Time.timeScale = 0;
            telaVitoria.SetActive(true);
        }
    }

    private void itLost()
    {
        Debug.Log("Voce perdeu!");
        Time.timeScale = 0;
        telaDerrota.SetActive(true); // Liga a tela de derrota
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
