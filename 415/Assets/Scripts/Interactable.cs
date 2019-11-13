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

    public void DoInteraction()
    {
        //picked up and put in inventory
        gameObject.SetActive(false);

    }

    public void Open()
    {
        anim.SetBool("open", true);
    }

    public void talk()
    {
        Debug.Log(message);
    }

    

}
