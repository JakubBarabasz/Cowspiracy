using UnityEngine;
using Random = System.Random;
public class EnemyBomb : MonoBehaviour
{
    public bool collide = false;
    public int hitsPoints;
    public float Speed = 0.1f;
    public float time = 5;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeHit(hitsPoints);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}