using UnityEngine;
using UnityEngine.Events;

public class GetKeyDown : MonoBehaviour
{
    public UnityEvent pressedLeft, pressedRight, pressedUp;
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
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pressedUp.Invoke();
        }
    }
}
