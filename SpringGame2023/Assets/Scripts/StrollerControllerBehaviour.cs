using UnityEngine;

public class StrollerControllerBehaviour : VehicleBase
{
    private Transform transformObj;

    public void JumpLeft()
    {
        Debug.Log("Swipe Detected");
        transform.position.Set(-1, transformObj.position.y, transformObj.position.z);
    }
}
