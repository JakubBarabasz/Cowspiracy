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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().GetCoins(coins);
            Destroy(gameObject);
        }
    }
}
