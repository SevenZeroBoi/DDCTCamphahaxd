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
    }

    public bool isDialoguePlaying { get; private set; }

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private Story currentStory;

    private void Start()
    {
        isDialoguePlaying = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) //trigger dialouge
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        //anim of dialog panel

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
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
