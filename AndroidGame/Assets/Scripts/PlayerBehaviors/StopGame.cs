using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public GameObject StopScreen;
    public GameObject Controlls1;
    public GameObject Controlls2;
    public GameObject Controlls3;
    public GameObject Controlls4;
    private void Start()
    {
        StopScreen.gameObject.SetActive(false);
        Controlls1.gameObject.SetActive(true);
        Controlls2.gameObject.SetActive(true);
        Controlls3.gameObject.SetActive(true);
        Controlls4.gameObject.SetActive(true);
    }
    public void Stop()
    {
        StopScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        Controlls1.gameObject.SetActive(false);
        Controlls2.gameObject.SetActive(false);
        Controlls3.gameObject.SetActive(false);
        Controlls4.gameObject.SetActive(false);
    }
    public void Resume()
    {
        StopScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
        Controlls1.gameObject.SetActive(true);
        Controlls2.gameObject.SetActive(true);
        Controlls3.gameObject.SetActive(true);
        Controlls4.gameObject.SetActive(true);
    }
}

