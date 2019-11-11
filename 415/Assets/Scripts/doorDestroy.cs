using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorDestroy : MonoBehaviour
{
    public Dialogue dialogue;
    bool dialogueStart = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueStart) {

        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.Destroy(GameObject.Find("Door"));
            // Debug.Log("clickced");
            dialogueStart = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
    

}
