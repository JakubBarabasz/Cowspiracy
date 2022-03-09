using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public float HP;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            player.GetHealth(HP);
            Destroy(gameObject);
        }
    }
}
