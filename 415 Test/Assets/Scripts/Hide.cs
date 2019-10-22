using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX;
    private float moveSpeed = 5;
    private SpriteRenderer rend;
    private bool canHide = false;
    public bool hiding = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (canHide && Input.GetKey("up"))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = 0;
            hiding = true;
           
            transform.position += new Vector3(0, 0, 1);
          if (Input.GetKeyUp("up"))  {
                transform.position = new Vector3(-5, 0, 4);
            }
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 2;
            hiding = false;
            if (canHide && Input.GetKey("down"))
            {
                transform.position += new Vector3(0, 0, -1);
            }
        }
    }
    private void FixedUpdate()
    {
        if(!hiding)
        
            rb.velocity = new Vector2(dirX, rb.velocity.y);
            else 
                rb.velocity = Vector2.zero;
        
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
