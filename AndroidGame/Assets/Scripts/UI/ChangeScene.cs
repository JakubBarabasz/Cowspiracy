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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pressCount++;
            Debug.Log("Button Pressed" + pressCount);
        }
        if (pressCount % 2 == 0)
        {
            StageControll.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            StageControll.gameObject.SetActive(true);
            Time.timeScale = 1;
        }

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