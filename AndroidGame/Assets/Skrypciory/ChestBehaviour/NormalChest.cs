using UnityEngine;

public class NormalChest : MonoBehaviour
{
    public int howManyBullets { get; } = 2;
    public int howManyDiscs { get; } = 1;
    void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerBehaviour>();
        if (player)
        {
            player.GetHealth(3);
        }
    }

}