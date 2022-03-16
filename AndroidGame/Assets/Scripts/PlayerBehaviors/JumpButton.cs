using UnityEngine;

public class JumpButton : MonoBehaviour
{
	public AudioSource jumpAudio;
	public Animator anim;
	public Transform feetPos;
	public LayerMask whatIsGround;
	public float checkRadious;
	public bool isGrounded = false;
	public float jumpSpeed = 1f;
	public float jumpForce = 0.00002f;
	private bool canjump;
	public Rigidbody2D _rigidbody;
	public Joystick joystick;
	public float movementVertical;

	void Start()
    {
		canjump = true;
		_rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

    void Update()
	{
		isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadious, whatIsGround);
        if (isGrounded)
        {
			anim.SetBool("isJumping", false);
		}
        else
        {
			anim.SetBool("isJumping", true);
		}
		movementVertical = joystick.Vertical;
		StartLetsJump();
	}
	
	public void StartLetsJump(){


        if (movementVertical >= .25f)
		{
			if (canjump && isGrounded)
			{
				jumpAudio.Play();
				isGrounded = false;
				_rigidbody.velocity = Vector2.up * jumpForce;
			}
		}
	}
	
}
