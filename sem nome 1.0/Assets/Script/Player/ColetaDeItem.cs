using System.Threading;
using TMPro;
using UnityEngine;

public class ColetaDeItem : MonoBehaviour
{
    public static ColetaDeItem ci;

    public GameController gcPlayer;

    public string tagParaContar = "Item";
    public int qntTotalItens; // Variável para armazenar a quantidade total de itens

    private void Awake()
    {
        if (ci == null)
        {
            ci = this;
        }
    }
    private void Start()
    {
        qntTotalItens = defQntItens(); // Atribui a quantidade total de itens com a tag especificada
        gcPlayer = GameController.gc;
        gcPlayer.itens = 0;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            gcPlayer.itens++;
            gcPlayer.itensText.text = gcPlayer.itens.ToString(); // Altera o texto da quantidade de itens na tela
        }
    }
}