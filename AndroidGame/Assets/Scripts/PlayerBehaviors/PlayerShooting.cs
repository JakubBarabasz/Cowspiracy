using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    public float coolDownTime = 2;
    public float nextFireTime = 0;
    public AudioSource getKnifes;
    public TextMeshProUGUI knifeUIAmount;
    public GameObject knife;
    public Transform throwPos;
    public int knifeAmount = 0;
    public AudioSource throwSound;
    void Start()
    {
        anim = GetComponent<Animator>();
        throwSound = GetComponent<AudioSource>();
       knifeAmount = PlayerPrefs.GetInt("playerKnifes");
    }
    public void Update()
    {
        PlayerPrefs.SetInt("playerKnifes", knifeAmount);
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
            if (knifeAmount > 0)
            {
                StartCoroutine(AnimCOOLDown());
            }
        }
    }

    IEnumerator AnimCOOLDown()
    {
        anim.SetBool("isThrowing", true);
        yield return new WaitForSecondsRealtime(0.15f);
        throwSound.Play();
        knifeAmount--;
        var newKnife = Instantiate(knife) as GameObject;
        newKnife.transform.position = throwPos.position;
        newKnife.transform.rotation = transform.rotation;
        nextFireTime = Time.time + coolDownTime;
        Destroy(newKnife, 0.5f);
        anim.SetBool("isThrowing", false);
    }
}