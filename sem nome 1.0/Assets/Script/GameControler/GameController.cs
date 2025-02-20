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
    public string tagParaContar = "Item";

    public TextMeshProUGUI vidaText;
    public int vidas = 3;

    private int qntTotalItens; // Variável para armazenar a quantidade total de itens

    private void Awake()
    {
        if (gc == null)
        {
            gc = this;
        }
        else if (gc != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Atribui a quantidade total de itens com a tag especificada
        qntTotalItens = defQntItens();
    }

    private int defQntItens()
    {
        GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag(tagParaContar);

        // Conta a quantidade de objetos encontrados
        int qntdItens = objetosComTag.Length;

        // Exibe a quantidade no console
        Debug.Log("Quantidade de objetos com a tag '" + tagParaContar + "': " + qntdItens);

        return qntdItens;
    }

    private void Update()
    {
        TimeCount();

        if (itens == qntTotalItens)
        {
            Debug.Log("Você ganhou!");
            Time.timeScale = 0;
        }
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
                Debug.Log("Voce perdeu!");
                Time.timeScale = 0;
            }
        }
    }
}