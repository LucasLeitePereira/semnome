using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudançadeCena : MonoBehaviour
{
    [SerializeField] private string CenaJogar;
    public void Jogar()
    {
        Debug.Log("Inciando o jogo");
        SceneManager.LoadScene(CenaJogar);
    }

    public void Sair()
    {
        Debug.Log("Saindo do Jogo");
        Application.Quit();
    }
}
