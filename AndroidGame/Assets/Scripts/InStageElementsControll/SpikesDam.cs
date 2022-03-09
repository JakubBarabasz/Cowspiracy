using UnityEngine;

public class SpikesDam : MonoBehaviour
{
    public float Damage;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            player.TakeHit(Damage);
        }
    }
}
