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

    public bool isOrder = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        animState = GetComponent<AnimationState>();
    }

    private void Update()
    {
        if (animState.name == "npcidle" && !isOrder)
        {
            Invoke("CharacterOrder", 2f);
            isOrder = true;
        }

        if (isOrder)
        {
            countdownCheck -= Time.deltaTime;
            if (countdownCheck <= 0)
            {

            }

            
        }
    }


    GameObject itemWanted;
    void CharacterOrder()
    {
        int randomitemwanted = Random.Range(0, ItemStorage.instance.combindingItems.Count);
        itemWanted = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key;
        ItemStorage.instance.currentItemCode = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Value.ToList();
        DialogueManager.instance.EnterDialogueMode(DialogueTest);
        
    }
}
