using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public bool selections;
    public GameObject cookedFood;


    public void TriggerDialogue()
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

            GameObject.Destroy(GameObject.Find("cookedTrigger"));
            cookedFood.SetActive(true);
            GameObject.Destroy(GameObject.Find("Pot_Lid"));

        }

    }

    public void OnCollisionExit2D(Collision2D other)
    {
    }
}
