using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public PlayerHealthbar Healthbar;
    private Rigidbody2D _rigidbody;
    private float horizontalMove;
    private float verticalmove;
    public Vector3 respawnPoint;
    public GameObject DeathScreen;
    public float MovementSpeed = 5;
    public bool isCollide = false;
    public float Hitpoints = 10;
    public float MaxHitpoints = 5;
    public int pressCount = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Hitpoints = MaxHitpoints;
        MaxHitpoints = 11;
        Hitpoints = 11;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        respawnPoint = transform.position;
        DeathScreen.gameObject.SetActive(false);
        TakeHit(1);
    }
    void Update()
    {

        var movement = joystick.Horizontal;

        if(movement >= .2f)
        {
            horizontalMove = MovementSpeed;
        }else if(movement <= -.2f)
        {
            horizontalMove = -MovementSpeed;
        }
        else
        {
            horizontalMove = 0;
        }

         transform.position += MovementSpeed * Time.deltaTime * new Vector3(movement, 0, 0);

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pressCount++;
            Debug.Log("Button Pressed" + pressCount);
        }

        if (Hitpoints <= 0)
        {
            DeathScreen.gameObject.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
            if (pressCount >=1)
            {
                Time.timeScale = 1;
                DeathScreen.gameObject.SetActive(true);
                Hitpoints = 11;
                TakeHit(1);
            }
        }
    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }
    public void GetHealth(float damage)
    {
        Hitpoints += damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.gameObject.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }

    }
}
