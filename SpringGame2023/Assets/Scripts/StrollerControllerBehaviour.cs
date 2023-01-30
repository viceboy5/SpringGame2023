using System;
using UnityEngine;

public class StrollerControllerBehaviour : VehicleBase
{
    public GameObject stroller;
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private Vector3 centerPosition;

    private void Start()
    {
        leftPosition.Set(stroller.transform.position.x -1, stroller.transform.position.y, stroller.transform.position.z);
        rightPosition.Set(stroller.transform.position.x +1, stroller.transform.position.y, stroller.transform.position.z);
        
    }

    public void MoveLeft()
    {
        Debug.Log("Swipe Detected");
        stroller.transform.position = leftPosition;
    }
}
