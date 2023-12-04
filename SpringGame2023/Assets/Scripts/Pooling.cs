using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Pooling : MonoBehaviour
{
    public Vector3Data nextLocation;
    public List<GameObject> activePool;
    public List<GameObject> inactivePool;
    public UnityEvent startEvent;

    private void Start()
    {
        startEvent.Invoke();
    }


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
    
    public void RandomizeActivePoolPositions(float randomOffset)
    {
        if (activePool.Count == 0)
        {
            // No objects in the active pool, nothing to randomize
            return;
        }

        float firstZ = activePool[0].transform.position.z; // Get the Z position of the first object

        List<float> availableZPositions = new List<float>();

        // Populate the availableZPositions list with increments
        for (int i = 0; i < activePool.Count; i++)
        {
            availableZPositions.Add(i * randomOffset);
        }

        // Shuffle the list to randomize the order
        for (int i = 0; i < availableZPositions.Count; i++)
        {
            float temp = availableZPositions[i];
            int randomIndex = Random.Range(i, availableZPositions.Count);
            availableZPositions[i] = availableZPositions[randomIndex];
            availableZPositions[randomIndex] = temp;
        }

        // Assign each object to a unique Z position
        for (int i = 0; i < activePool.Count; i++)
        {
            if (activePool[i] != null)
            {
                // Set the object's position
                float zPosition = availableZPositions[i] + firstZ; // Add the starting Z position
                activePool[i].transform.position = new Vector3(nextLocation.value.x, nextLocation.value.y, zPosition);
                Debug.Log(zPosition);
            }
        }
    }
}
