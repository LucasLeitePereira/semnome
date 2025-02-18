using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    public float rotationSpeed = 10f; // Velocidade de rotação

    void Update()
    {
        // Obter entrada do teclado (setas)
        float horizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        float vertical = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;

        // Normalizar o vetor para evitar movimento mais rápido na diagonal
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Movimentar o personagem
        if (moveDirection.magnitude >= 0.1f)
        {
            // Atualizar a posição do personagem no espaço global
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // Calcular a rotação desejada na direção do movimento
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Suavizar a rotação
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}




