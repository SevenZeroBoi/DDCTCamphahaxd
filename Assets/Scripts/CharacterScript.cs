using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void Start()
    {
        anim = GetComponent<Animator>();
        animState = GetComponent<AnimationState>();
    }

    private void Update()
    {
        if (animState.name == "npcidle" && !GameStates.instance.isCharacterOrder)
        {
            CharacterOrder();
            GameStates.instance.isCharacterOrder = true;
        }

        if (GameStates.instance.isCharacterOrder)
        {
            countdownCheck -= Time.deltaTime;
            if (countdownCheck <= 0)
            {

            }

            
        }
    }
    void DialogueDelay()
    {
        //yield return new WaitForSeconds(2);
        DialogueManager.instance.EnterDialogueMode(DialogueTest);
    }
    void CharacterOrder()
    {
        int randomitemwanted = Random.Range(0, ItemStorage.instance.combindingItems.Count);
        GameStates.instance.currentNeededItem = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key;
        GameStates.instance.currentItemCode = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Value.ToList();
        Invoke("DialogueDelay", 2);
    }
}
