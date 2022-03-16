using UnityEngine;
using Random = System.Random;

public class AddCoins : MonoBehaviour
{
    int minValue = 4;
    int maxValue = 10;
    Random rnd = new Random();
    private int coins;
    void Start()
    {
        coins = rnd.Next(minValue, maxValue);
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
