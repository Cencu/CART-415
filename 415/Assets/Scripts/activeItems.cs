using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeItems : MonoBehaviour
{

    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void foodActive()
    {
        food.SetActive(true);
    }

}
