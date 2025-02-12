using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaDeItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual colidimos � o item
        if (other.CompareTag("Item"))
        {
            // Aqui voc� pode adicionar o c�digo para aumentar algum valor (ex: pontua��o)
            CollectItem(other.gameObject);
        }
    }

    // M�todo para coletar o item
    private void CollectItem(GameObject item)
    {
        // Exibe uma mensagem no console (opcional)
        Debug.Log("Item coletado!");

        // Aqui voc� pode adicionar ao invent�rio ou algo do tipo
        // Exemplo simples: destruir o item
        Destroy(item);
    }
}



