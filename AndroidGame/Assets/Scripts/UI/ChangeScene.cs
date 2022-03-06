using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [System.Obsolete]
    public GameObject StageControll;
    int pressCount = 0; // global
    private void Start()
    {
        StageControll.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ChangeToScene(string sceneChangeto)
    {
        Application.LoadLevel(sceneChangeto);
    }
    private void Update()
    {


    }

    public void StageMenu()
    {
        Application.Quit();
    }
    public void Quit()
    {
        Application.Quit();

    }

}