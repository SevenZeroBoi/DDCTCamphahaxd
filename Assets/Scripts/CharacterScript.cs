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

    Animator anim;


    public TextAsset pickText;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("npcidle") && !GameStates.instance.isCharacterOrder)
        {
            CharacterOrder();
            GameStates.instance.isCharacterOrder = true;
        }
    }
    public void CharacterOrder()
    {
        int randomitemwanted = Random.Range(0, ItemStorage.instance.combindingItems.Count);
        GameStates.instance.currentNeededItem = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key;
        GameStates.instance.currentItemCode = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Value.ToList();
        GameStates.instance.isCharacterOrder = true;
        DialogueManager.instance.EnterDialogueMode(DialogueTest);
    }
}
