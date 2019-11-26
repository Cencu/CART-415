using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VIDE_Data;

public class PlayerMovement : MonoBehaviour
{
    private Animator mAnim;

    public string playerName = "Scotty";
    [SerializeField]
    public float moveSpeed = 10f;

    private bool facingRight;
    private bool walking = false;
    public bool dead = false;

    public GameObject menuPanel;
    public Text messageText;

    public VIDE_Assign inTrigger;
    public VIDEUIManager1 diagUI;

    private Rigidbody2D myRigidbody;

   // public bool gotItem;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
        //At start, wait for player to start
       // Time.timeScale = 0f;
        //make panel visible 
       // menuPanel.SetActive(false);
         Time.timeScale = 1f;
        facingRight = true;
        //  messageText.text = "Press Play to Start";
    }

    private void Update()
    {
        //Debug.Log(inTrigger);
        /*if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("left") || Input.GetKey("right"))
        {
            walking = true;
        } else
        {
            walking = false;
        }

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        mAnim.SetBool("Walking", walking);

    */
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);

        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }

    }

    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y);
        mAnim.SetFloat("speed",Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void TryInteract()
    {
        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            // Debug.Log("interacted");
            return;
        }

    }

    public void startButton()
    {
        //menuPanel.SetActive(false);
        //Time.timeScale = 1f;

        //to use as a restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public void death()
    {
        if (dead)
        {
            menuPanel.SetActive(true);
            messageText.text = "Game Over";
        }
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit button has been pressed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
            
        }
    }
    void OnTriggerExit()
    {
        inTrigger = null;
    }
}
