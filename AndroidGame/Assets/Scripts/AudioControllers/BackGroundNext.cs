using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundNext : MonoBehaviour
 {
    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}