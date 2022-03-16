using UnityEngine;

public class MovingPlatformHorizontal : MonoBehaviour
{
    public bool isOnPlatform;
    public GameObject player;
    public GameObject playerHook;
    public float moveSpeed;
    public bool moveUp;
    void Update()
    {

        if (isOnPlatform == true)
        {
            player.transform.SetParent(gameObject.transform);
        }
        else if(isOnPlatform == false)
        {
            player.transform.SetParent(playerHook.transform);
        }
  
        if (moveUp)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z - 0.0000001f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z - 0.0000001f);
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

    public void OnCollisionStay2D(Collision2D collision)
    {
        var playerColl = collision.collider.gameObject.tag == "Player";
        if (playerColl)
        {
            isOnPlatform = true;
        }
        else
        {
            isOnPlatform = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isOnPlatform = false;
    }
}
