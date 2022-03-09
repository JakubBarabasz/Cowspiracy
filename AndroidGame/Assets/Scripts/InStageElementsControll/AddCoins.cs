using UnityEngine;
using Random = System.Random;

public class AddCoins : MonoBehaviour
{
    Random rnd = new Random();
    private int coins;
    void Start()
    {
        coins = rnd.Next(4, 10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            player.GetCoins(coins);
            Destroy(gameObject);
        }
    }
}
