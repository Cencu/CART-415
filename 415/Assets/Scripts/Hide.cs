using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    
    public bool canHide = false;
    public bool hiding = false;


    private void Update()
    {
        if (canHide)
        {
            if (Input.GetKeyDown("w"))
            {
                transform.Translate(0, 0, -Time.deltaTime*970);
                Debug.Log("w");
            }
        }
        if (canHide)
        {
            if (Input.GetKeyDown("s"))
            {
                transform.Translate(0, 0, -Time.deltaTime * -970);
                Debug.Log("w");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Gate_Door"))
        {
            canHide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Gate_Door"))
        {
            canHide = false;
        }
    }
}
