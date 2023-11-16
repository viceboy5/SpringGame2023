using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public Vector3Data nextLocation;
    public List<GameObject> activePool;
    public List<GameObject> inactivePool;
    

    public void RandomSpawnFromPoolIncremental(float v3Adjustment)
    {
        if (activePool.Count > 0)
        {
            int randomIndex = Random.Range(0, inactivePool.Count);
            GameObject inactiveObj = inactivePool[randomIndex];

            if (inactiveObj != null)
            {
                inactiveObj.SetActive(true);
                inactiveObj.transform.position = nextLocation.value;
                nextLocation.value.z += v3Adjustment;
                
                activePool.Add(inactiveObj);
                inactivePool.RemoveAt(randomIndex);
            }
        }
    }

    public void MoveToInactivePool(GameObject obj)
    {
        activePool.Remove(obj);
        inactivePool.Add(obj);
        obj.SetActive(false);
    }
}
