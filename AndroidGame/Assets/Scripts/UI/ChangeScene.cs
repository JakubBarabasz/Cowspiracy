using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void ChangeToScene(string sceneChangeTo)
    {
        StartCoroutine(LoadLevel(sceneChangeTo));
    }
    public void Quit()
    {
        Application.Quit();

    }
    IEnumerator LoadLevel(string nextScene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextScene);
    }

}