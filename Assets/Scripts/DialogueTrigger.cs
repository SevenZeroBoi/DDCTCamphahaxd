using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] bool canStartDialogue = false;

    public TextAsset textJSON;


    private void Update()
    {
        BeginDialogue();
    }
    void BeginDialogue()
    {
        if (canStartDialogue)
        {
            if (Input.GetKeyDown(KeyCode.A)) //start dialog
            {
                DialogueManager.instance.EnterDialogueMode(textJSON);
            }
        }
    }
}
