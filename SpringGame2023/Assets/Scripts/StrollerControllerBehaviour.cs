using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]


public class StrollerControllerBehaviour : MonoBehaviour
{
    public GameObject stroller;
    public UnityEvent triggerEnterEvent;
    private Rigidbody rigidbodyObj;
    
    public Vector3 direction;
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private Vector3 centerPosition;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        rigidbodyObj = GetComponent<Rigidbody>();
    }
    
    private void Start()
    {
        leftPosition.Set(stroller.transform.position.x -1, stroller.transform.position.y, stroller.transform.position.z);
        rightPosition.Set(stroller.transform.position.x +1, stroller.transform.position.y, stroller.transform.position.z);
        
    }

    public void MoveLeft()
    {
        Debug.Log("Swipe Detected");
        if (stroller.transform.position.x > -1)
        {
            leftPosition.Set(stroller.transform.position.x -1, stroller.transform.position.y, stroller.transform.position.z);
            stroller.transform.position = leftPosition;
        }
    }

    public void MoveRight()
    {
        Debug.Log("Swipe Detected");
        if (stroller.transform.position.x < 1)
        {
            rightPosition.Set(stroller.transform.position.x +1, stroller.transform.position.y, stroller.transform.position.z);
            stroller.transform.position = rightPosition;
        }
    }

    public void Jump()
    {
        Debug.Log("Swipe Detected");
        rigidbodyObj.AddForce(0,100,0);
    }
    
    public void Move()
    {
        rigidbodyObj.velocity = direction;
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
}
