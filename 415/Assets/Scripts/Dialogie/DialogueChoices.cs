using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoices : MonoBehaviour
{
    public GameObject DialogueBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public GameObject Choice04;
    public int ChoiceMade;

    public void ChoiceOption1()
    {
        DialogueBox.GetComponent<Text>().text = "Have a good one.";
        ChoiceMade = 1;
    }

    public void ChoiceOption2()
    {
        DialogueBox.GetComponent<Text>().text = "Bandits approach our village I hear. Best be hiding or getting away from here.";
        ChoiceMade = 2;
    }

  /*  public void ChoiceOption3()
    {
        textBox.GetComponent<Text>().text = "Have a good one.";
        ChoiceMade = 1;
    }

    public void ChoiceOption4()
    {
        textBox.GetComponent<Text>().text = "Have a good one.";
        ChoiceMade = 1;
    }*/

    // Update is called once per frame
    void Update()
    {
        if (ChoiceMade >=  1)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
        }
    }
}
