using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetKeyDown : MonoBehaviour
{
    public UnityEvent pressedLeft, pressedRight;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pressedLeft.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pressedRight.Invoke();
        }
    }
}
