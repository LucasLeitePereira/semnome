using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPlayers : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento
    public float rotationSpeed = 10f; // Velocidade de rotação

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    void Update()
    {
        // Obter entrada do teclado
        float horizontal = Input.GetKey(right) ? 1 : Input.GetKey(left) ? -1 : 0;
        float vertical = Input.GetKey(up) ? 1 : Input.GetKey(down) ? -1 : 0;
        
        float eixoX = transform.position.x;
        float eixoZ = transform.position.z;
        transform.position = new Vector3(eixoX, 1, eixoZ);

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
