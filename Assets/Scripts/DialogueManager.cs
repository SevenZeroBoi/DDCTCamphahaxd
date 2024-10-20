using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        instance = this;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public bool canStartDialogue = false;

    public TextAsset textJSON;

    public bool isDialoguePlaying { get; private set; }

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;

    private void Start()
    {
        isDialoguePlaying = false;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    void BeginDialogue()
    {
        if (canStartDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Return)) //start dialog
            {
                EnterDialogueMode(textJSON);
                canStartDialogue = false;
            }
        }
    }

    void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
