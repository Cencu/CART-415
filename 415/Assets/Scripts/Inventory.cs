using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[6];
    public Button[] InventoryButtons = new Button[6];
    //public GameObject item;
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                //Update UI
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
               
            }
        }
        if (!itemAdded)
        {
            Debug.Log("Inventory Full");
        }
    }


    public bool ReceiveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //found item
                return true;
            }
        }
        //item not found
        return false;
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                //found item
                return true;
            }
        }
        //item not found
        return false;
    }
    public GameObject FindItemByType(string itemType)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if(inventory[i].GetComponent<Interactable>().itemType == itemType)
                {
                    //we found the item we're looking for 
                    return inventory[i]; 
                }
            }
        }
        // item of type not found 
        return null;
    }



    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {

                //we remove the item
                inventory[i] = null;
                InventoryButtons[i].image.overrideSprite = null;
                Debug.Log(item.name + " Was Removed");
                break;
                
            }
        }
    }
   
}
