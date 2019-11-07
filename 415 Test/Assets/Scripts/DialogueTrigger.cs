using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;

    public void TriggerDialogue ()
    {

       // Debug.Log("clickced");
        //GameObject.Destroy(GameObject.Find("Door"));

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }

}
