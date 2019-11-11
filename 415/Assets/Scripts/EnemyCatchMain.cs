using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatchMain : MonoBehaviour
{
    float dirX;
    float moveSpeed = 3f;
    public Hide hide;
    Rigidbody2D rb;

    [SerializeField]
    GameObject Found;
    // Start is called before the first frame update
    void Start()
    {
        Found.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x > 9f)
            dirX = -1f;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("MainChar") )
            Found.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("MainChar") )
            Found.SetActive(false);
    }
}
