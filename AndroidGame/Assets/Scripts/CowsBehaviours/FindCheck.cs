using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCheck : MonoBehaviour
{
    public GameObject greenFlag;
    public GameObject redFlag;
    public bool nextStage = false;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        greenFlag.SetActive(false);
        redFlag.SetActive(true);
    }
    void Update()
    {
        if(nextStage == true)
        {
            greenFlag.SetActive(true);
            redFlag.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            nextStage = true;
            anim.SetBool("FoundCow", true);
        }
    }
}
