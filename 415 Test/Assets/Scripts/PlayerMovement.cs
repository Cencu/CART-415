using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator mAnim;
    
    public float moveSpeed = 10f;
    private bool walking = false;
    // Start is called before the first frame update
    void Start()
    {

        mAnim = GetComponent<Animator>();

    }

    private void Update()
    {

        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            walking = true;
          //  Debug.Log(walking);
        } else
        {
            walking = false;
        }

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        // walking = true;
        mAnim.SetBool("Walking", walking);
    }
    
}
