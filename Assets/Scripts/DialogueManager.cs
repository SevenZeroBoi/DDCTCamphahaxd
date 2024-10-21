using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    void OnEnable()
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


    public void ContinueStory()
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
