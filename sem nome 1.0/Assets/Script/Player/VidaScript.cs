using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaScript : MonoBehaviour
{
    public bool alive = true;
    public GameController gcPlayer;
    private bool isIntangible = false;

    [SerializeField] private LayerMask enemyLayer;
    private Collider playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        isDead();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Colisão com: {other.gameObject.name} (Layer: {other.gameObject.layer})");

        if (other.gameObject.tag == "Inimigos" && !isIntangible)
        {
            if (gcPlayer.lives > 0)
            {
                gcPlayer.lives--;
                gcPlayer.vidaText.text = gcPlayer.lives.ToString();
                StartCoroutine(ActivateIntangibility());
            }
            else if (gcPlayer.lives == 0)
            {
                if (gcPlayer != null) gcPlayer.lives = 0;
                alive = false;
            }
        }
    }

    private void isDead()
    {
        if (!alive)
        {
            Time.timeScale = 0;
            Debug.Log("Você morreu!");
        }
    }

    private IEnumerator ActivateIntangibility()
    {
        isIntangible = true;

        // Verifica se as layers existem
        int playerLayer = LayerMask.NameToLayer("Player");
        int enemyLayer = LayerMask.NameToLayer("Enemy");

        if (playerLayer == -1 || enemyLayer == -1)
        {
            Debug.LogError("Layers não configuradas corretamente!");
            yield break;
        }

        // Ignora colisões entre Player e Enemy
        Physics.IgnoreLayerCollision(playerLayer, enemyLayer, true);

        yield return new WaitForSecondsRealtime(2f);

        // Restaura colisões
        Physics.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        isIntangible = false;
    }

    // Método auxiliar para verificar layers
    private bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return (layerMask.value & (1 << layer)) != 0;
    }
}