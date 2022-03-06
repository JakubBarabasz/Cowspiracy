using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI knifeUIAmount;
    public GameObject knife;
    public Transform throwPos;
    public int knifeAmount = 0;

    void Start()
    {
        /**for (int i = 0; i <= 14; i++)
        {
            KnifeAmmo[i].gameObject.SetActive(false);
        }*/

    }
    public void Update()
    { 
        knifeUIAmount.text = Convert.ToString(knifeAmount);
    }
    public void GetKnife(int knifes)
    {
        knifeAmount += knifes;
    }
    //Strzał
    public void Shoot()
    {
        if (knifeAmount > 0)
        {
            knifeAmount--;
            var newKnife = Instantiate(knife) as GameObject;
            newKnife.transform.position = throwPos.position;
            newKnife.transform.rotation = transform.rotation;
            //KnifeAmmo[knifeAmount].gameObject.SetActive(false);
            Destroy(newKnife, 1);
        }
        //~~TODO usunąć CheatCode 
        if (Input.GetKeyDown(KeyCode.R))
        {
            knifeUIAmount.text = Convert.ToString(knifeAmount);
            knifeAmount = 12;
            /**  for (int i = 0; i <= 12; i++)
              {
                  KnifeAmmo[i].gameObject.SetActive(true);
              }*/
        }
    }
    /**
NormalChest nC = new NormalChest();
RareChest rC = new RareChest();
SuperDuperFrickingChest sC = new SuperDuperFrickingChest();
void OnCollisionEnter2D(Collision2D coll)
{
if (coll.gameObject.tag == "NormalChest")
{
ammoAmout += nC.howManyBullets;
discAmout += nC.howManyDiscs;
for (int i = 0; i <= ammoAmout - 1; i++)
{
    Bulletammo[i].gameObject.SetActive(true);
}
for (int i = 0; i <= discAmout - 1; i++)
{
    Discammo[i].gameObject.SetActive(true);
}
Destroy(coll.gameObject);
}
if (coll.gameObject.tag == "RareChest")
{
ammoAmout += rC.howManyBullets;
discAmout += rC.howManyDiscs;
for (int i = 0; i <= ammoAmout - 1; i++)
{
    Bulletammo[i].gameObject.SetActive(true);
}
for (int i = 0; i <= discAmout - 1; i++)
{
    Discammo[i].gameObject.SetActive(true);
}
Destroy(coll.gameObject);
}
if (coll.gameObject.tag == "SuperDuperFrickingChest")
{

ammoAmout += sC.howManyBullets;
discAmout += sC.howManyDiscs;
for (int i = 0; i <= ammoAmout - 1; i++)
{
    Bulletammo[i].gameObject.SetActive(true);
}
for (int i = 0; i <= discAmout - 1; i++)
{
    Discammo[i].gameObject.SetActive(true);
}
Destroy(coll.gameObject);
}

}
        */
}