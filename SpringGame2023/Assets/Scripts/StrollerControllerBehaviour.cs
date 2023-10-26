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
    
    public float speed;
    public float height;
    public float groundedDist;

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
        if (stroller.transform.position.x > -1)
        {
            leftPosition.Set(stroller.transform.position.x -1, stroller.transform.position.y, stroller.transform.position.z);
            stroller.transform.position = leftPosition;
        }
    }

    public void MoveRight()
    {
        if (stroller.transform.position.x < 1)
        {
            rightPosition.Set(stroller.transform.position.x +1, stroller.transform.position.y, stroller.transform.position.z);
            stroller.transform.position = rightPosition;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rigidbodyObj.AddForce(0, height, 0);
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

    public void ResetPosition(Vector3Data startPos)
    {
        stroller.transform.position = startPos.value;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, Vector3.down, out hit, groundedDist);
    }
    

    public void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
}
