using UnityEngine;

public class SpikesDam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            player.TakeHit(4);
        }
    }
}
