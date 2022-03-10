using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
	public GameObject invisibleHIT;
	public AudioSource meleeSound;
	public Animator anim;
	public Transform hitPos;
	public LayerMask whatIsEnemy;
	public float checkRadious;
	public bool isEnemy = false;
	public Rigidbody2D _rigidbody;

    void Start()
    {
		_rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

    void Update()
	{
		isEnemy = Physics2D.OverlapCircle(hitPos.position, checkRadious, whatIsEnemy);
        if (isEnemy)
        {
			//var InvisibleHIT = Instantiate(invisibleHIT) as GameObject;
		}
        else
        {

		}
    }
	
	public void StartHit(){
		if (isEnemy)
		{
			meleeSound.Play();
		}
	}
	
}
