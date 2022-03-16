using UnityEngine;
using Random = System.Random;

public class AddKnife : MonoBehaviour
{
    int minValue = 1;
    int maxValue = 6;

    Random rnd = new Random();
    private int knifes;
    void Start()
    {
        knifes = rnd.Next(minValue, maxValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerShooting>();
        if (player)
        {
            player.GetKnife(knifes);
            Destroy(gameObject);
        }
    }
}
