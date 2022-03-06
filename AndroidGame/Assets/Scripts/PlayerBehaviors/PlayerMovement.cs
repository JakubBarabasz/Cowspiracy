using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody2D _rigidbody;
    public TextMeshProUGUI HPUIAmount;
    public TextMeshProUGUI CoinsUIAmount;
    private float horizontalMove;
    private float verticalmove;
    public Vector3 respawnPoint;
    public GameObject DeathScreen;
    public float MovementSpeed = 5;
    public bool isCollide = false;
    public float Hitpoints = 10;
    public float MaxHitpoints = 5;
    public float coins = 0;
    public GameObject Controlls1;
    public GameObject Controlls2;
    public GameObject Controlls3;
    public GameObject Controlls4;
    public GameObject Controlls5;
    public GameObject Controlls6;
    public GameObject Controlls7;

    void Start()
    {
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
        TakeHit(5);
    }
    void Update()
    {
        HPUIAmount.text = Convert.ToString(Hitpoints);
        CoinsUIAmount.text = Convert.ToString(coins);
        var movement = joystick.Horizontal;

        if(movement >= .2f)
        {
            horizontalMove = MovementSpeed;
        }else if(movement <= -.2f)
        {
            horizontalMove = -MovementSpeed;
        }
        else
        {
            horizontalMove = 0;
        }

         transform.position += MovementSpeed * Time.deltaTime * new Vector3(movement, 0, 0);

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

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
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    public void GetCoins(float addMoney)
    {
        coins += addMoney;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
    }
    public void GetHealth(float damage)
    {
        Hitpoints += damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.gameObject.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }

    }
}
