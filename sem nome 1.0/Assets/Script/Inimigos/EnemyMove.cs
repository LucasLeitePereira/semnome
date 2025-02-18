using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove3D : MonoBehaviour
{
    public float speed = 2f;
    public float rayDistance = 6f;
    public Transform rayOrigin; // Ponto de origem do raycast (arraste um EmptyObject para c�)
    public float rotation;

    void Update()
    {
        // Move o inimigo
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Desenha o raycast na cena (para debug visual)
        Debug.DrawRay(rayOrigin.position, transform.forward * rayDistance, Color.red);

        // Detecta colis�o com parede
        RaycastHit hit;
        bool isWall = Physics.Raycast(
            rayOrigin.position,
            transform.forward,
            out hit,
            rayDistance
        );

        if (isWall)
        {
            Debug.Log("Colidiu com: " + hit.collider.name); // Mostra o nome do objeto colidido

            if (hit.collider.CompareTag("Wall"))
            {
                Debug.Log("Girando 90 graus!"); // Confirma��o de que a tag foi detectada
                transform.Rotate(0, rotation, 0);
            }
            else
            {
                Debug.LogWarning("Objeto colidido n�o tem tag 'Wall'."); // Aviso de tag ausente
            }
        }
        else
        {
            Debug.Log("Nenhuma colis�o detectada."); // Aviso se o raycast n�o atingiu nada
        }
    }
}