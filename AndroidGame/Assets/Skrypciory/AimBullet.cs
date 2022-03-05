using UnityEngine;

public class AimBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float howManyHits;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(howManyHits);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}