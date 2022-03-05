using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float MovementSpeed = 5;
    public float jumpForce = 0.00002f;
    public bool isGrounded;
    public bool isJumping;
    public float jumpTime;
    public float jumpTimeCounter;
    public bool isCollide = false;
    private Rigidbody2D _rigidbody;
    public float Hitpoints = 10;
    public float MaxHitpoints = 5;
    public PlayerHealthbar Healthbar;
    public Vector3 respawnPoint;
    public Transform feetPos;
    public GameObject DeathScreen;
    public float checkRadious;
    public LayerMask whatIsGround;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public int pressCount = 0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Hitpoints = 10;
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        respawnPoint = transform.position;
        DeathScreen.gameObject.SetActive(false);
        Hitpoints = 11;
        TakeHit(1);
    }
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadious, whatIsGround);
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //fixed double jump bug
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //lets player jump
        if (isGrounded == true && Input.GetKeyDown("space") && isJumping == false)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            _rigidbody.velocity = Vector2.up * jumpForce;
        }

        //makes you jump higher when you hold down space
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if (jumpTimeCounter > 0)
            {
                _rigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;

            }
        }

        var movement = Input.GetAxis("Horizontal");

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
