using System.Collections;
using UnityEngine;
using Random = System.Random;

public class EnemyBehaviour : MonoBehaviour
{
    public float hitValue = 1;
    public float hitSeconds = 0.7f;
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
        if (0 >= Hitpoints)
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
        var player = collision.collider.GetComponent<PlayerMovement>();
  
            if (isCollPlayer && canTakeDamage)
            {
                StartCoroutine(WaitForSeconds());
                player.TakeHit(hitValue);
            }
    }
    IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(hitSeconds);
        canTakeDamage = true;
    }
}
