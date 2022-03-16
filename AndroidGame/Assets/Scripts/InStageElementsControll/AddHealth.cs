using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public float HP;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            player.UpgradeMaxHealth(5);
            player.GetHealth(HP);
            Destroy(gameObject);
        }
    }
}
