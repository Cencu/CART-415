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

    public float moveSpeed = 10f;
    private bool walking = false;
    public bool dead = false;

    public GameObject menuPanel;
    public Text messageText;

    public VIDE_Assign inTrigger;
    public VIDEUIManager1 diagUI;

    // Start is called before the first frame update
    void Start()
    {

        mAnim = GetComponent<Animator>();
        //At start, wait for player to start
       // Time.timeScale = 0f;
        //make panel visible 
        menuPanel.SetActive(false);
         Time.timeScale = 1f;

        //  messageText.text = "Press Play to Start";
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

       /* if (!VD.isActive)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);
            float move = Input.GetAxisRaw("Vertical");
            transform.position += transform.forward * 7 * move * Time.deltaTime;
            
        }*/

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
           // Debug.Log("interacted");
        }

    }

    void TryInteract()
    {
        if(inTrigger)
        {
            diagUI.Interact(inTrigger);
            Debug.Log("interacted");
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
