using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TouchSwipeBehaviour))]
[RequireComponent(typeof(Rigidbody))]
public class DirectionalSwipeBehaviour : MonoBehaviour
{
     public float force = 10f;
     private Rigidbody rb;
     private TouchSwipeBehaviour touchSwipeBehaviourObj;
     public UnityEvent swipeRightEvent, swipeLeftEvent, swipeUpEvent, swipeDownEvent;
     
     private void OnEnable()
     {
          rb = GetComponent<Rigidbody>();
          touchSwipeBehaviourObj = GetComponent<TouchSwipeBehaviour>();
          touchSwipeBehaviourObj.sendTouchData += GetSwipeDirection;
     }

     private void GetSwipeDirection(TouchData data)
     {
          Vector3 swipeDirection = data.direction;

          // Get the absolute values of horizontal and vertical components
          float horizontal = Mathf.Abs(swipeDirection.x);
          float vertical = Mathf.Abs(swipeDirection.y);

          if (horizontal > vertical)
          {
               if (swipeDirection.x > 0)
               {
                    ApplyMovement("Swipe Right");
               }
               else
               {
                    ApplyMovement("Swipe Left");
               }
          }
          else
          {
               if (swipeDirection.y > 0)
               {
                    ApplyMovement("Swipe Up");
               }
               else
               {
                    ApplyMovement("Swipe Down");
               }
          }
     }

     private void ApplyMovement(string direction)
     {
          // Add code here to apply the specific movement based on the direction
          // For example:
           if (direction == "Swipe Up")
           {
               swipeUpEvent.Invoke();
           }
           
           if (direction == "Swipe Down")
           {
                swipeDownEvent.Invoke();
           }
          
           if (direction == "Swipe Right")
           {
                swipeRightEvent.Invoke();
           }
           
           if (direction == "Swipe Left")
           {
                swipeLeftEvent.Invoke();
           }
     }
}
