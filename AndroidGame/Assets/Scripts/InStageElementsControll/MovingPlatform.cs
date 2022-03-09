using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public bool moveUp;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {

        var upElement = collision.collider.gameObject.tag == "upElement";
        var downElement = collision.collider.gameObject.tag == "downElement";
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
