using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class VidaScript : MonoBehaviour
{
    public static VidaScript vs;

    public bool alive = true;
    public GameController gcPlayer;

    private Vector3 positionInitial;

    private void Awake()
    {
        if (vs == null)
        {
            vs = this;
        }
    }
    private void Start()
    {
        positionInitial = transform.position;
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

}
