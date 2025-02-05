using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    public BarraDeVida barra;
    private float vida = 100;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100.0f;
        barra.ColocarVidaMaxima(vida);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            vida -= 10.0f;
            barra.AlterarVida(vida);
        }
        
    }
}
