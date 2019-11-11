using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBino : MonoBehaviour
{
    //on click 
    // trigger binotrigger 
    //show text
    public GameObject binoButton;
    public bool buttonActive;

    void Start()
    {
        buttonActive = false;
    }
    private void OnMouseDown()
    {
        buttonActive = true;
        Debug.Log(buttonActive);

    }

    private void OnMouseUp()
    {
        buttonActive = false;
        Debug.Log(buttonActive);
    }
}
