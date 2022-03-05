using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{

    void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }
    }
}
