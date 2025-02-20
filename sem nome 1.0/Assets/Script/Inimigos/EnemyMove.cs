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
}