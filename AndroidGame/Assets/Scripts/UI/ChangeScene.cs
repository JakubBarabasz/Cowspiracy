using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [System.Obsolete]
    public GameObject StageControll;

    [System.Obsolete]
    private void Start()
    {
        StageControll.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    [System.Obsolete]
    public void ChangeToScene(string sceneChangeto)
    {
        Application.LoadLevel(sceneChangeto);
    }
    private void Update()
    {


    }

    public void Quit()
    {
        Application.Quit();

    }

}