using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public float Speed;


    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.right * Speed * Time.deltaTime;
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
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}