using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove3D : MonoBehaviour
{
    public float speed = 2f;
    public float rayDistance = 6f;
    public Transform rayOrigin; // Ponto de origem do raycast (arraste um EmptyObject para cá)
    public float rotation;
    
    
    void Update()
    {
        // Move o inimigo
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Desenha o raycast na cena (para debug visual)
        Debug.DrawRay(rayOrigin.position, transform.forward * rayDistance, Color.red);

        // Detecta colisão com parede
        RaycastHit hit;
        bool isWall = Physics.Raycast(
            rayOrigin.position,
            transform.forward,
            out hit,
            rayDistance
        );

        if (isWall)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                transform.Rotate(0, rotation, 0);
            }
        }

    }

    private void OnCollisionEnter(Collision collision) // Script que serve para o inimigo não girar ao colidir com o player
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Impede que o inimigo gire ao colidir com o jogador
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.angularVelocity = Vector3.zero; // Zera a velocidade angular
                rb.velocity = Vector3.zero; // Zera a velocidade linear (opcional)
            }

            // Aqui você pode adicionar a lógica para o jogador perder vida e voltar ao ponto de partida
            Debug.Log("Colidiu com o jogador!");
        }
    }
}