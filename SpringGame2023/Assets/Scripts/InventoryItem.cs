using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{ 
    public int price;
    public bool own;
    public bool canPurchase = true;
    public UnityEvent useEvent;
    public GameAction gameActionobj;

    public void Purchase(IntData cash)
    {
        if (cash.value >= price && canPurchase == true)
        {
            cash.value -= price;
            own = true;
            canPurchase = false;
        }

        else
        {
            Debug.Log("cannot purchase");
        }
    }

    public void UseItem()
    {
        if (own == true)
        {
            useEvent.Invoke();
            own = false;
            gameActionobj.RaiseAction();
        }
        else
        {
            Debug.Log("don't own");
        }
        
    }
}
