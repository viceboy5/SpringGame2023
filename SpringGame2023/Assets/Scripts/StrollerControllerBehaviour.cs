using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]


public class StrollerControllerBehaviour : MonoBehaviour
{
    public GameObject stroller;
    public UnityEvent triggerEnterEvent;
    private Rigidbody rigidbodyObj;
    
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private Vector3 centerPosition;
    
    private bool canJump = true;
    private WaitForSeconds wfsObj;
    public float seconds;
    public float speed;
    public float height;

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
        if (canJump)
        {
            rigidbodyObj.AddForce(0, height, 0);
            StartCoroutine(WaitForSeconds());
        }
    }
    
    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private IEnumerator WaitForSeconds()
    {
        Debug.Log("Waiting to Jump");
        wfsObj = new WaitForSeconds(seconds);
        canJump = false;
        yield return wfsObj;
        canJump = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
}
