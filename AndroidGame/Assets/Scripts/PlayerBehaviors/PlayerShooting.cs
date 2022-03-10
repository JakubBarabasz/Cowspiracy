using TMPro;
using UnityEngine;
using System;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    public AudioSource getKnifes;
    public TextMeshProUGUI knifeUIAmount;
    public GameObject knife;
    public Transform throwPos;
    public int knifeAmount = 0;
    public AudioSource throwSound;
    void Start()
    {
        throwSound = GetComponent<AudioSource>();
    }
    public void Update()
    { 
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
        if (knifeAmount > 0)
        {
            throwSound.Play();
            knifeAmount--;
            var newKnife = Instantiate(knife) as GameObject;
            newKnife.transform.position = throwPos.position;
            newKnife.transform.rotation = transform.rotation;
            Destroy(newKnife, 1);
        }
    }}