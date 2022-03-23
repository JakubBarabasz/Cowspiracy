using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    public float coolDownTime = 0.6f;
    public float nextFireTime = 0;
    public AudioSource getKnifes;
    public TextMeshProUGUI knifeUIAmount;
    public GameObject knife;
    public Transform throwPos;
    public int knifeAmount = 0;
    public AudioSource throwSound;
    void Start()
    {
        coolDownTime = 0.2f;
        anim = GetComponent<Animator>();
        throwSound = GetComponent<AudioSource>();
   //    knifeAmount = PlayerPrefs.GetInt("playerKnifes");
    }
    public void Update()
    {
      //  PlayerPrefs.SetInt("playerKnifes", knifeAmount);
        knifeUIAmount.text = Convert.ToString(knifeAmount);
    }
    public int GetKnife(int knifes)
    {
        getKnifes.Play();
        knifeAmount += knifes;
        return knifes;
    }
    //Strzał
    public void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            anim.SetBool("isThrowing", false);

            if (knifeAmount > 0)
            {
                anim.SetBool("isThrowing", true);
                StartCoroutine(AnimCOOLDown());
                IEnumerator AnimCOOLDown()
                {
                    throwSound.Play();
                    knifeAmount--;
                    var newKnife = Instantiate(knife) as GameObject;
                    newKnife.transform.position = throwPos.position;
                    newKnife.transform.rotation = transform.rotation;
                    nextFireTime = Time.time + coolDownTime;
                    yield return new WaitForSecondsRealtime(0.15f);
                    Destroy(newKnife, 0.35f);
                    anim.SetBool("isThrowing", false);
                }
            }
        }
    }
}