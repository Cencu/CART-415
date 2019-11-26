using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookedFoodTrigger : MonoBehaviour
{
    public GameObject endScene;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            endScene.SetActive(true);
           
        }

    }
 

}
