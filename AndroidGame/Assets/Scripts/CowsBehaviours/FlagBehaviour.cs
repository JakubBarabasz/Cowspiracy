using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBehaviour : MonoBehaviour
{
    public GameObject player;
    public string nextScene;
    public string thisScene;
    [System.Obsolete]
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
            SceneManager.MoveGameObjectToScene(player.gameObject, SceneManager.GetSceneByName(nextScene));
     
        }
    }
}

