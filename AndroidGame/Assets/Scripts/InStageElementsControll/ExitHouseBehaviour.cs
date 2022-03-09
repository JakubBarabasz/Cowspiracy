using UnityEngine;

public class ExitHouseBehaviour : MonoBehaviour
{
    public GameObject exitPopUp;
    public Vector3 exitPosition;
    public bool isInExitDoors = false;
    public Transform player;
    public void Start()
    {
        exitPopUp.SetActive(false);
    }

    public void Update()
    {

        if (isInExitDoors == true)
        {
            exitPopUp.SetActive(true);
        }
        else if (isInExitDoors == false)
        {
            exitPopUp.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GetComponent<PlayerMovement>();

        if (collision.collider.gameObject.tag == "Player")
        {
            isInExitDoors = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            isInExitDoors = false;
        }
    }
    public void onUIClickExit()
    {
        player.transform.position = exitPosition;
        exitPopUp.SetActive(false);
    }
}
