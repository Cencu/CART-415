using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public Interactable currentInterObjScript = null;
    public Inventory inventory;


    private void Update()
    {
        if(Input.GetButtonDown("Interact") && currentInterObj)
        {
            //check to see if this object is going to be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
                if (currentInterObj && currentInterObjScript)
                {
                    currentInterObj = null;
                    currentInterObjScript = null;
                }
            }
            //check if it can be opened
            if (currentInterObjScript.openable)
            {
                //check to see if its locked
                if (currentInterObjScript.locked)
                {
                    //check to see if we have the key
                    //search inventory and if we have the item we unlock door
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //found item
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                    } else
                    {
                        Debug.Log(currentInterObj.name + "was not unlocked");
                    }
                } else
                {
                    // object not locked, open object
                    Debug.Log(currentInterObj.name + " is already unlocked");
                    currentInterObjScript.Open();
                }
            }

            //If the object has a message
            if (currentInterObjScript.talks)
            {
                currentInterObjScript.talk();
            }

        }

        //use items 
        if (Input.GetButtonDown("Interact"))
        {
            //check inventory for item
            GameObject key = inventory.FindItemByType("Key_B"); 
            if (key != null)
            {
                //use item and apply effect
                inventory.RemoveItem(key);
            }

            GameObject food = inventory.FindItemByType("Food");
            if (food != null)
            {
                //use item and remove
                inventory.RemoveItem(food);
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }

}
