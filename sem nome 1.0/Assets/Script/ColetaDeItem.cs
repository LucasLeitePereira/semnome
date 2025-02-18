using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaDeItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto com o qual colidimos é o item
        if (other.CompareTag("Item"))
        {
            // Aqui você pode adicionar o código para aumentar algum valor (ex: pontuação)
            CollectItem(other.gameObject);
        }
    }

    // Método para coletar o item
    private void CollectItem(GameObject item)
    {
        // Exibe uma mensagem no console (opcional)
        Debug.Log("Item coletado!");

        // Aqui você pode adicionar ao inventário ou algo do tipo
        // Exemplo simples: destruir o item
        Destroy(item);
    }
}



