using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool haveMoney;
    public GameObject InShopAlertNoMoney;
    public Animator anim;
    public AudioSource healthSound;
    public AudioSource coinsSound;
    public Joystick joystick;
    private Rigidbody2D _rigidbody;
    public TextMeshProUGUI HPUIAmount;
    public TextMeshProUGUI CoinsUIAmount;
    private float horizontalMove;
    private float verticalmove;
    public Vector3 respawnPoint;
    public float MovementSpeed = 5;
    public bool isCollide = false;
    public float Hitpoints = 10;
    public float MaxHitpoints = 5;
    public float coins = 0;
    public float playerHitStrength = 2;
    public GameObject Controlls1;
    public GameObject Controlls2;
    public GameObject Controlls3;
    public GameObject Controlls4;
    public GameObject Controlls5;
    public GameObject Controlls6;
    public GameObject Controlls7;
    public GameObject DeathScreen;
    public GameObject ShopScreen;
    public bool isCollEnemy = false;
    private bool canTakeDamage = true;

    void Start()
    {
        haveMoney = false;
        InShopAlertNoMoney.SetActive(false);
        anim = GetComponent<Animator>();
        Application.targetFrameRate = 60;
        _rigidbody = GetComponent<Rigidbody2D>();
        Hitpoints = MaxHitpoints;
        MaxHitpoints = 10;
        Hitpoints = 10;
        coins = 0;
        respawnPoint = transform.position;
        DeathScreen.gameObject.SetActive(false);
        Controlls1.gameObject.SetActive(false);
        Controlls2.gameObject.SetActive(false);
        Controlls3.gameObject.SetActive(false);
        Controlls4.gameObject.SetActive(false);
        Controlls5.gameObject.SetActive(false);
        Controlls6.gameObject.SetActive(false);
        Controlls7.gameObject.SetActive(false);
        DeathScreen.gameObject.SetActive(false);
        ShopScreen.gameObject.SetActive(false);
        TakeHit(5);
    }
    void Update()
    {
        if (coins <= 0) { }
        else
        {
            haveMoney = true;
        }
        HPUIAmount.text = Convert.ToString(Hitpoints + " / " + MaxHitpoints);
        CoinsUIAmount.text = Convert.ToString(coins);
        var movement = joystick.Horizontal;

        if(movement >= .2f)
        {
            horizontalMove = MovementSpeed;
            anim.SetBool("isRunning", true);
        }
        else if(movement <= -.2f)
        {
            horizontalMove = -MovementSpeed;
            anim.SetBool("isRunning", true);
        }
        else
        {
            horizontalMove = 0;
            anim.SetBool("isRunning", false);
        }

        //_rigidbody.AddForce(Vector2.right * MovementSpeed);
         transform.position += MovementSpeed * Time.deltaTime * new Vector3(movement, 0, 0);
      
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if(Hitpoints > MaxHitpoints)
        {
            Hitpoints = MaxHitpoints;
        }


        if (Hitpoints <= 0)
        {
            DeathScreen.gameObject.SetActive(true);
            Controlls1.gameObject.SetActive(false);
            Controlls2.gameObject.SetActive(false);
            Controlls3.gameObject.SetActive(false);
            Controlls4.gameObject.SetActive(false);
            Controlls5.gameObject.SetActive(false);
            Controlls6.gameObject.SetActive(false);
            Controlls7.gameObject.SetActive(false);
            ShopScreen.gameObject.SetActive(false);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    public void GetCoins(float addMoney)
    {
        coinsSound.Play();
        coins += addMoney;
    }
    public void LoseCoins(float loseMoney)
    {
        coins -= loseMoney;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
    }
    public void GetHealth(float damage)
    {
        healthSound.Play();
        Hitpoints += damage;
    }
    public void UpgradeMaxHealth(float damage)
    {
        MaxHitpoints += damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.gameObject.tag == "CheckPoint")
        {
            isCollide = true;
            respawnPoint = transform.position;
        }

        if(collision.gameObject.tag == "Merchant")
        {
            Controlls1.gameObject.SetActive(false);
            Controlls2.gameObject.SetActive(false);
            Controlls3.gameObject.SetActive(false);
            Controlls4.gameObject.SetActive(false);
            Controlls5.gameObject.SetActive(true);
            Controlls6.gameObject.SetActive(true);
            Controlls7.gameObject.SetActive(true);
            ShopScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            horizontalMove = 0;
        }
    }

    public void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Merchant")
        {
            Controlls1.gameObject.SetActive(true);
            Controlls2.gameObject.SetActive(true);
            Controlls3.gameObject.SetActive(true);
            Controlls4.gameObject.SetActive(true);
            Controlls5.gameObject.SetActive(true);
            Controlls6.gameObject.SetActive(true);
            Controlls7.gameObject.SetActive(true);
            ShopScreen.gameObject.SetActive(false);
        };
    }

    /// <summary>
    /// Shop Behaviours
    /// </summary>
    /// <returns>buying methods</returns>
    public bool GetHaveMoney()
    {
        return haveMoney;
    }

    public void BuyHP()
    {
        if(coins <= 4)
        {
            InShopAlertNoMoney.SetActive(true);
        }
        else
        {
            LoseCoins(5);
            GetHealth(50);
            InShopAlertNoMoney.SetActive(false);
        }
    }

    public void BuyMaxHP()
    {
        if (coins <= 19)
        {
            InShopAlertNoMoney.SetActive(true);
        }
        else
        {
            LoseCoins(20);
            UpgradeMaxHealth(3);
            InShopAlertNoMoney.SetActive(false);
        }
    }

}
