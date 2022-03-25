using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePlatform : MonoBehaviour
{
    public bool isStanding;
    public float seconds = 5;
    public bool isVisible;
    public Collider2D coll;
    private void Start()
    {
        coll.isTrigger = false;
        isVisible = true;
        isStanding = false;
    }
    public void Update()
    {
        if(isVisible == false)
        {
            coll.isTrigger = true;
            gameObject.GetComponent<Renderer>().enabled = false;
            StartCoroutine(WaitToAppear());
        }
        if (isVisible == true)
        {
            coll.isTrigger = false;
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isStanding = true;
            StartCoroutine(WaitToDisappear());
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
            isStanding = false;
    }

    IEnumerator WaitToDisappear()
    {
        yield return new WaitForSecondsRealtime(seconds);
        isVisible = false;
        yield return new WaitForSecondsRealtime(seconds);
        isVisible = true;
    }

    IEnumerator WaitToAppear()
    {
        yield return new WaitForSecondsRealtime(seconds);
        isVisible = true;

    }
}
