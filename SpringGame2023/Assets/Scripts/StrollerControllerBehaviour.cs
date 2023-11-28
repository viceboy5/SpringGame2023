using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]


public class StrollerControllerBehaviour : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, checkpointEvent;
    private Rigidbody rigidbodyObj;
    
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    private Vector3 centerPosition;
    
    public FloatData speedObj;
    public FloatData checkpointDist;
    public float jumpHeight = 100;
    public float diveForce = -50;
    public float groundedDist = .3f;
    public float tempSpeed;
    private float playerSpeed;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        rigidbodyObj = GetComponent<Rigidbody>();
        Transform strollerTransform = transform;
    }
    
    private void Start()
    {
        leftPosition.Set(transform.position.x -1, transform.position.y, transform.position.z);
        rightPosition.Set(transform.position.x +1, transform.position.y, transform.position.z);
        speedObj.value = 3.5f;
    }

    private void Update()
    {
        float distanceToCheckpoint = Mathf.Abs(transform.position.z - checkpointDist.value);
        playerSpeed = speedObj.value;
        if (distanceToCheckpoint < 0.1f)
        {
            checkpointEvent.Invoke();
        }
    }

    public void MoveLeft()
    {
        if (transform.position.x > -1)
        {
            leftPosition.Set(transform.position.x -1, transform.position.y, transform.position.z);
            transform.position = leftPosition;
        }
    }

    public void MoveRight()
    {
        if (transform.position.x < 1)
        {
            rightPosition.Set(transform.position.x +1, transform.position.y, transform.position.z);
            transform.position = rightPosition;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rigidbodyObj.AddForce(0, jumpHeight, 0);
        }
    }

    public void Dive()
    {
        if (!IsGrounded())
        {
            rigidbodyObj.AddForce(0, diveForce, 0);
        }
    }
    
    public void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
    }

    public void TempSpeed(float newSpeed)
    {
        tempSpeed = speedObj.value;
        Debug.Log(tempSpeed);
        speedObj.value = newSpeed;
    }

    public void ResetSpeed()
    {
        speedObj.value = tempSpeed;
        Debug.Log(tempSpeed);
    }

    public void ResetPosition(Vector3Data startPos)
    {
        transform.position = startPos.value;
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
