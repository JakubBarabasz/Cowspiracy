using UnityEngine;
using Random = System.Random;

public class AddKnife : MonoBehaviour
{
    Random rnd = new Random();
    private int knifes;
    void Start()
    {

        knifes = rnd.Next(1, 6);
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
