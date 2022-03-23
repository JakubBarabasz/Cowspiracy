using System.Collections;
using UnityEngine;
using Random = System.Random;
public class PlayerMelee : MonoBehaviour
{
    Random rand = new Random();
    [SerializeField]
    public AudioSource punch01;
    public AudioSource punch02;
    public AudioSource punch03;
    public AudioSource punch04;
    public GameObject InvisiblePunch;
    public Transform meleePos;
    public int whatSound;

    public Animator anim;
    public float coolDownTime = 0.4f;

    public float nextPunchTime = 0;

    void Start()
    {
        coolDownTime = 0.4f;
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        whatSound = rand.Next(1, 4);
    }

    //Strza³
    public void Punch()
    {

        if (Time.time > nextPunchTime)
        {
            StartCoroutine(AnimCOOLDown());
            IEnumerator AnimCOOLDown()
            {
                anim.SetBool("isHitting", true);
                yield return new WaitForSecondsRealtime(0);
                if (whatSound == 1)
                {
                    punch01.Play();
                }
                else if (whatSound == 2)
                {
                    punch02.Play();
                }
                else if (whatSound == 3)
                {
                    punch03.Play();
                }
                else if (whatSound == 4)
                {
                    punch04.Play();
                }
                var newPunch = Instantiate(InvisiblePunch) as GameObject;
                newPunch.transform.position = meleePos.position;
                newPunch.transform.rotation = transform.rotation;
                nextPunchTime = Time.time + coolDownTime;
                anim.SetBool("isHitting", false);
                Destroy(newPunch, 0.35f);
            }
        }
    }
}