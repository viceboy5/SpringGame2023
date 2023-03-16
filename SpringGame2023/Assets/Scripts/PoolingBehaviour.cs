//Created from Professor Anthony Romrell's Pooling Behaviour shown in class and available at public repo https://github.com/anthonyromrell/ArtisanDream.Tools

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolingBehaviour : MonoBehaviour
{
    public List<Transform> poolList;
    public UnityEvent startEvent, awakeEvent, poolEvent;
    public float seconds = 2f;
    private WaitForSeconds wfsObj;
    private int i;
    public bool canRun = true;
    public float holdTime = 3f;

    private void Awake()
    {
        awakeEvent.Invoke();
        wfsObj = new WaitForSeconds(holdTime);
    }

    IEnumerator Start()
    {
        yield return wfsObj;
        startEvent.Invoke();
        wfsObj = new WaitForSeconds(seconds);
        while (canRun)
        {
            yield return wfsObj;
            poolEvent.Invoke();
            poolList[i].position = Vector3.zero;
            poolList[i].gameObject.SetActive(true);
            i++;
            if (i > poolList.Count - 1)
            {
                i = 0;
            }
        }
    }
}
