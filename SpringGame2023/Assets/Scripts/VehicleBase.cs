using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class VehicleBase : MonoBehaviour, IMove, ITrigger
{
    public UnityEvent triggerEnterEvent;
    private Rigidbody rigidbodyObj;
    
    public Vector3 direction;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        rigidbodyObj = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        rigidbodyObj.transform += direction;
        print("Moving my Car!");
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }
}
