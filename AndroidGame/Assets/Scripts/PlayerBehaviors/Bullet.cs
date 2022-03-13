using UnityEngine;
using Random = System.Random;
public class Bullet : MonoBehaviour
{
    public bool randomHit;
    public int hitsPoints;
    public Rigidbody2D _rigidbody;
    public float Speed;


    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.right * Speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (randomHit)
        {
            Random rand = new Random();
            if (enemy)
            {
                enemy.TakeHit(rand.Next(1,5));
                Destroy(gameObject);
            }
        }
        else
        {
            if (enemy)
            {
                enemy.TakeHit(hitsPoints);
                Destroy(gameObject);
            }
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