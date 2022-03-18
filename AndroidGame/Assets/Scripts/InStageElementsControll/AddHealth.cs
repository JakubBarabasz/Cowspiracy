using UnityEngine;

public class AddHealth : MonoBehaviour
{
    public float HP;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().GetHealth(HP);
            collision.gameObject.GetComponent<PlayerMovement>().UpgradeMaxHealth(5);
            Destroy(gameObject);
        }
    }
}
