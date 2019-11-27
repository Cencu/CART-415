using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeItems : MonoBehaviour
{

    public GameObject Item;

    public Inventory inventoryScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addToInv()
    {
        Item.SetActive(false);
        inventoryScript.AddItem(Item);

    }
   

}
