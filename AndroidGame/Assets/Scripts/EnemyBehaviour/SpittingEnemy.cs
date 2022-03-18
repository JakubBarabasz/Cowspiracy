using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpittingEnemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public GameObject bullet;
    public Transform player;
    public Transform shootPos;
    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots < -0)
        {
            var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.transform.position = shootPos.position;
            Destroy(newBullet, 5f);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
