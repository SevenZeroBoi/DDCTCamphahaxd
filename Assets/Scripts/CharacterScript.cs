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

    public float countdownCheck = 5f;

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

        if (GameStates.instance.isCharacterOrder)
        {
            countdownCheck -= Time.deltaTime;
            if (countdownCheck <= 0)
            {
                countdownCheck = 5;
            }

            
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
