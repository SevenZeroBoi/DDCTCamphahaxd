using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool canStartDialogue = false;

    public TextAsset textJSON;

    public static DialogueTrigger instance;

    private void Awake()
    {
        instance = this;
        
    }

    private void Update()
    {
        BeginDialogue();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SetUpNewDialogue(textJSON);
        }
    }
    void BeginDialogue()
    {
        if (canStartDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Return)) //start dialog
            {
                DialogueManager.instance.EnterDialogueMode(textJSON);
                canStartDialogue = false;
            }
        }
    }

    public void SetUpNewDialogue(TextAsset newtextJSON) //when new customer came in
    {
        textJSON = newtextJSON;
        canStartDialogue = true;
    }

    /*
    public void CustomerCantHoldItXD()
    {
        textJSON = null;
    }*/
}
