using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    public Rigidbody2D rigidbodyTwo;
    public float SpeedTwo;


    private void FixedUpdate()
    {
        rigidbodyTwo.velocity = transform.right * SpeedTwo * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(1);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        /**
        if (collision.collider.CompareTag("Chest"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
        
        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        */
    }
}