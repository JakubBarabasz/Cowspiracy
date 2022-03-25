using UnityEngine;

public class JumpButton : MonoBehaviour
{
	public AudioSource jumpAudio;
	public Animator anim;
	public Transform feetPos;
	public LayerMask whatIsGround;
	public float checkRadious = 0.1f;
	public bool isGrounded = false;
	public float jumpSpeed = 1f;
	public float jumpForce = 23f;
	private bool canjump;
	public Rigidbody2D _rigidbody;
	public Joystick joystick;
	public float movementVertical;

	void Start()
    {
		jumpForce = 23f;
		canjump = true;
		_rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

    void Update()
	{
		checkRadious = 0.13f;
		jumpForce = 23f;
		isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadious, whatIsGround);
        if (isGrounded)
        {
			anim.SetBool("isJumping", false);
		}
		if (!isGrounded)
		{
			anim.SetBool("isJumping", true);
			anim.SetBool("isRunning", false);

		}
		movementVertical = joystick.Vertical;
		StartLetsJump();
	}
	
	public void StartLetsJump(){
		if (movementVertical >= .4f)
		{
			if (canjump && isGrounded)
			{
				jumpAudio.Play();
				isGrounded = false;
				_rigidbody.velocity = Vector2.up * jumpForce;
			}
		}
	}

	public void jumpButton()
	{
		if (canjump && isGrounded)
		{
			jumpAudio.Play();
			isGrounded = false;
			_rigidbody.velocity = Vector2.up * jumpForce;
		}
	}

}
