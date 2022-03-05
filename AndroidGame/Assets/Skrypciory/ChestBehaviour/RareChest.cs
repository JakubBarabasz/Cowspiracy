using UnityEngine;

public class RareChest : MonoBehaviour
{
    public int howManyBullets { get; } = 3;
    public int howManyDiscs { get; } = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player)
        {
            player.GetHealth(5);
        }
    }
}
