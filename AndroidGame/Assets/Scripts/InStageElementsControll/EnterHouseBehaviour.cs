using UnityEngine;

public class EnterHouseBehaviour : MonoBehaviour
{
    public GameObject enterPopUp;
    public Vector3 housePosition;
    public bool isInEnterDoors = false;
    public Transform player;
    public void Start()
    {
        enterPopUp.SetActive(false);
    }

    public void Update()
    {
        if (isInEnterDoors == true)
        {
            enterPopUp.SetActive(true);
        }
        else if (isInEnterDoors == false)
        {
            enterPopUp.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = GetComponent<PlayerMovement>();
    
       if(collision.collider.gameObject.tag == "Player")
        {
            isInEnterDoors = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            isInEnterDoors = false;
        }
    }

    public void onUIClickEnter()
    {
        player.transform.position = housePosition;
        enterPopUp.SetActive(false);
    }

}
