
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    enum CharacterState
    {
        WAITING, COMPLETE, WRONGITEM, TIMEOUT
    }

    Animator anim;

    public Dictionary<GameObject, TextAsset> pickText;
    public TextAsset[] possibleText;

    bool kuy = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        //pickText = new Dictionary<GameObject, TextAsset>();

        pickText = new Dictionary<GameObject, TextAsset>();
        
        for (int i = 0; i < ItemStorage.instance.combindingItems.Count; i++)
        {
            pickText.Add(ItemStorage.instance.combindingItems.ElementAt(i).Key, possibleText[i % 4]);
        }
        /*
        var motion = CubismMotion.CreateFromJson("Assets/Live2D/Motions/your_animation.motion3.json");
        var model = GetComponent<CubismModel>();
        var motionController = model.gameObject.AddComponent<CubismMotionController>();
        motionController.Play(motion);
        */
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("npcidle") && kuy)
        {
            kuy = false;
            CharacterOrder();

        }
    }

    public void CharacterOrder()
    {
        int randomitemwanted = Random.Range(0, ItemStorage.instance.combindingItems.Count);
        GameObject currentItem = ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key;
        GameStates.instance.currentNeededItem = currentItem;
        GameStates.instance.currentItemCode = new List<string>();
        DialogueManager.instance.ExitDialogueMode();
        DialogueManager.instance.EnterDialogueMode(pickText[ItemStorage.instance.combindingItems.ElementAt(randomitemwanted).Key]);
        GameStates.instance.isCharacterOrder = true;

    }
}
