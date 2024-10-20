using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCharacter", menuName = "ScriptableObjects/Character")]
public class SO_Characters : ScriptableObject
{
    public string CharacterName;
    public GameObject CharacterObject;
    public Animator CharacterAnim;


    public TextAsset textForLump;
    public TextAsset textForHand;
    public TextAsset textForWalker;
    public TextAsset textForMaw;
    public TextAsset textForPeeper;

    public TextAsset possibleQuestion;
    public string[] possibleAnswer;

    

}
