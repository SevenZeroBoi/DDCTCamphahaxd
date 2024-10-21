using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Motion;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    enum CharacterState
    {
        WAITING, COMPLETE, WRONGITEM, TIMEOUT
    }



    Animator anim;


    public Dictionary<GameObject,TextAsset> pickText;
    public TextAsset[] possibleText;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pickText = new Dictionary<GameObject,TextAsset>();
        for (int i = 0; i < possibleText.Length; i++)
        {
            pickText.Add(ItemStorage.instance.combindingItems.ElementAt(i).Key, possibleText[i]);
        }
        for (int i = 0; i < possibleText.Length; i++)
        {
            pickText.Add(ItemStorage.instance.combindingItems.ElementAt(i + possibleText.Length).Key, possibleText[i]);
        }
        for (int i = 0; i < possibleText.Length; i++)
        {
            pickText.Add(ItemStorage.instance.combindingItems.ElementAt(i + (2*possibleText.Length)).Key, possibleText[i]);
        }

        /*
        var motion = CubismMotion.CreateFromJson("Assets/Live2D/Motions/your_animation.motion3.json");

        var model = GetComponent<CubismModel>();

        var motionController = model.gameObject.AddComponent<CubismMotionController>();
        motionController.Play(motion);*/
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("npcidle") && !GameStates.instance.isCharacterOrder)
        {
            CharacterOrder();
        }
    }
    public void CharacterOrder()
    {
        int randomitemwanted = Random.Range(0, ItemStorage.instance.combindingItems.Count);
        GameStates.instance.currentNeededItem = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key;
        GameStates.instance.currentItemCode = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Value.ToList();
        DialogueManager.instance.EnterDialogueMode(pickText[ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key]);
        GameStates.instance.isCharacterOrder = true;

    }


}


