using System.Threading;
using TMPro;
using UnityEngine;

public class ColetaDeItem : MonoBehaviour
{
    public int coins;
    public GameController gcPlayer;

    private void Start()
    {
        gcPlayer = GameController.gc;
        gcPlayer.itens = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            gcPlayer.itens++;
            gcPlayer.itensText.text = gcPlayer.itens.ToString();
        }
    }
}