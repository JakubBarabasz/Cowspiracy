using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
	
	public float jumpSpeed = 3f;
	public float jumpDelay = 2f;
	public float jumpForce = 0.00002f;
	private bool canjump;
	private bool isjumping;
	public Rigidbody2D _rigidbody;
	private float countDown;
	
    // Start is called before the first frame update
    void Start()
    {
        canjump = true;
		_rigidbody = GetComponent<Rigidbody2D>();
		countDown = jumpDelay;
    }

    // Update is called once per frame
    void Update()
    {
		if(isjumping && countDown > 0)
			countDown -= Time.deltaTime;
		else{
			canjump = true;
			isjumping = false;
			countDown = jumpDelay;
		}
			
    }
	
	public void StartLetsJump(){
		if(canjump){
			canjump = false;
			isjumping = true;
			_rigidbody.velocity = Vector2.up * jumpForce;
		}
	}
	
}
