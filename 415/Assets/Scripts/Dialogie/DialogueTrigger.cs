using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public bool selections;

    

    public void TriggerDialogue ()
    {

        // Debug.Log("clickced");
        //GameObject.Destroy(GameObject.Find("Door"));
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);


    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
            GameObject.Destroy(GameObject.Find("EatStart"));
            
        }
        
    }

    

}
