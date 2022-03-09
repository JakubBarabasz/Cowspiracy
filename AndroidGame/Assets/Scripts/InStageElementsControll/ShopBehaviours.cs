using System;
using TMPro;
using UnityEngine;
public class ShopBehaviours : MonoBehaviour
{
    PlayerMovement playerMovement = new PlayerMovement();
    PlayerShooting playerShooting = new PlayerShooting();

    public void Start()
    {
       
    }

    public void Uptade()
    {


    }


    public void BuyHP()
    {
        playerMovement.LoseCoins(5);
        //playerMovement.GetHealth(10);

    }

    public void BuyKnifes()
    {
        playerMovement.LoseCoins(2);
        playerShooting.GetKnife(1);
    }

}