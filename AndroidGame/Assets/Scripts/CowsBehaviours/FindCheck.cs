using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCheck : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        var player = collision.collider.GetComponent<PlayerMovement>();
        if (player)
        {
            anim.SetBool("FoundCow", true);
        }
    }
}
