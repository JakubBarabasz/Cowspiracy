using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public bool moveUp;
    // Update is called once per frame
    void Update()
    {

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var upElement = collision.collider.gameObject.tag == "Block";
        var downElement = collision.collider.gameObject.tag == "Chest";
        if (upElement)
        {
            moveUp = true;
        }
        if (downElement)
        {
            moveUp = false;
        }
    }
   
}
