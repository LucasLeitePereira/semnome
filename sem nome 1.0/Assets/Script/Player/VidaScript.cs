using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class VidaScript : MonoBehaviour
{
    public bool alive = true;
    public GameController gcPlayer;

    private Vector3 positionInitial;

    private void Start()
    {
        positionInitial = transform.position;
    }
    private void Update()
    {
        isDead();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Inimigos")
        {
            if (gcPlayer.vidas >= 0)
            {
                gcPlayer.vidas--;
                Debug.Log("-1 Vida!");
                gcPlayer.vidaText.text = gcPlayer.vidas.ToString();
                transform.position = positionInitial; // Volta o player para o ponto Inicial

                if (gcPlayer.vidas <= 0)
                {
                    gcPlayer.vidas = 0;
                    alive = false;
                } 
            }
        }
    }

    private void isDead()
    {
        if (!alive)
        {
            Debug.Log("Sem vidas restantes");
            Debug.Log("Voce perdeu!");
            Time.timeScale = 0;
            
        }
    }
}
