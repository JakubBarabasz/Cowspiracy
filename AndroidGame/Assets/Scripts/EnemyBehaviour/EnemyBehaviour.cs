using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public EnemyHealthBar Healthbar;
    public bool isCollPlayer = false;
    public AudioSource hitSound;

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

    private void OnCollisionEnter2D(Collision2D collision)
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
        if (player && isCollPlayer)
        {
            StartCoroutine(SomeCoroutine());
        }
        IEnumerator SomeCoroutine()
        {
            player.TakeHit(1);
            yield return new WaitForSeconds(1);
        }
    }
}
