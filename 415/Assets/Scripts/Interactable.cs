using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool inventory; //If true this object can be stored in inventory
    public bool openable;  //If true then this object can be opened
    public bool locked;    //If true then this object is locked
    public bool talks;     //If true then object can deliver a message

    public string itemType;//Tells us what type of item this object is 

    public GameObject itemNeeded; //Item needed in order to interact with item   
    public Animator anim;

    public string message;

    public Inventory inventoryScript;

    public float moveSpeed;

    private bool leaving;
   


    public void DoInteraction()
    {
        //picked up and put in inventory
        gameObject.SetActive(false);
        //Debug.Log(gameObject);
    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void leave()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        anim.SetBool("leave", true);
        leaving = true;
        Debug.Log(leaving);
    }

    private void Update()
    {
        if (leaving)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        }
    }

    public void GiveItem()
    {
        //Debug.Log(gameObject);
        //Debug.Log(itemIndex);
        /* player.demo_ItemInventory.Add(player.demo_Items[itemIndex]);
         itemPopUp.SetActive(true);
         string text = "You've got a <color=yellow>" + player.demo_Items[itemIndex] + "</color>!";
         itemPopUp.transform.GetChild(0).GetComponent<Text>().text = text;
         dialoguePaused = true;
        //
        */
        
        inventoryScript.AddItem(gameObject);

    }

    


    public void talk()
    {
        Debug.Log(message);
    }

    

}
