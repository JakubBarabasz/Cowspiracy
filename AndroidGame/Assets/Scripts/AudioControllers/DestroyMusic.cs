using UnityEngine;

public class DestroyMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}