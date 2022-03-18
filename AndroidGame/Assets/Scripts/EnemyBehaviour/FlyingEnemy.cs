using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    public GameObject player;
    public Vector3 shootPoint;
    public GameObject bullet;
    private float timeBtwShots;
    public float startTimeBtwShots;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if (chase == true)
        {
            Chase();
        }
        else
        {
            ReturnStartPoint();
        }


        Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (timeBtwShots < -0)
        {
            var newBullet = Instantiate(bullet, shootPoint, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            Destroy(newBullet, 2f);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.transform.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
