using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    enum CharacterState
    {
        WAITING, COMPLETE, WRONGITEM, TIMEOUT
    }


    public TextAsset DialogueTest;

    AnimationState animState;
    Animator anim;

    public float countdownCheck;

    public bool isOrder = false;
    public bool isGettingItem = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        animState = GetComponent<AnimationState>();
    }

    private void Update()
    {
        if (animState.name == "npcidle" && !isOrder)
        {
            CharacterOrder();
            isOrder = true;
        }

        if (isOrder)
        {
            countdownCheck -= Time.deltaTime;
            if (countdownCheck <= 0)
            {

            }

            if (isGettingItem)
            {

            }

            
        }
    }

    void CharacterOrder()
    {
        DialogueManager.instance.EnterDialogueMode(DialogueTest);
    }
}
