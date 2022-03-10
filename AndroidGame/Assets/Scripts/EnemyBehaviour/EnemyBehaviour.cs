using System.Collections;
using UnityEngine;
using Random = System.Random;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public EnemyHealthBar Healthbar;
    public bool isCollPlayer = false;
    public AudioSource hitSound;
    public bool canTakeDamage = true;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        hitSound = GetComponent<AudioSource>();
    }

    public void TakeHit(float damage)
    {
        hitSound.Play();
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollPlayer = true;
        }
        else
        {
            isCollPlayer = false;
        }
       // Random rnd = new Random();
        var player = collision.collider.GetComponent<PlayerMovement>();
   
            //int randHit = rnd.Next(3, 5);
            if (isCollPlayer && canTakeDamage)
            {
                StartCoroutine(WaitForSeconds());
                player.TakeHit(1);
            }
    }
    IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(0.7f);
        canTakeDamage = true;
    }
}
