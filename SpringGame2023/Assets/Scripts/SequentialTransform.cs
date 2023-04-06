using UnityEngine;

public class SequentialTransform : MonoBehaviour
{
    public Vector3Data nextLocation;

    public void MoveAndUpdateNext(float v3Adjustment)
    {
        transform.position = nextLocation.value;
        nextLocation.value.z += v3Adjustment;
    }
}
