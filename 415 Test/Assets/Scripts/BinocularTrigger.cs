using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinocularTrigger : MonoBehaviour
{
    public GameObject uiObject;
    public UseBino useBino;
    
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.gameObject.tag == "Enemy" && useBino.buttonActive == true)
        {
            uiObject.SetActive(true);
            
            //StartCoroutine("WaitForSec");
        }
    }

    private void OnTriggerExit2D(Collider2D Enemy)
    {
        if (Enemy.gameObject.tag == "Enemy" )
        {
            uiObject.SetActive(false);
        }
    }
    /*  IEnumerator WaitForSec()
      {
          yield return new WaitForSeconds(5);
          Destroy(uiObject);
          Destroy(gameObject);
      }*/
}

