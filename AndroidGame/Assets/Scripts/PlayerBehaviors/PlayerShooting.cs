using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
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
    public void GetKnife(int knifes)
    {
        getKnifes.Play();
        knifeAmount += knifes;
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
        //~~TODO usunąć CheatCode 
        if (Input.GetKeyDown(KeyCode.R))
        {
            knifeUIAmount.text = Convert.ToString(knifeAmount);
            knifeAmount = 12;
        }
    }
}