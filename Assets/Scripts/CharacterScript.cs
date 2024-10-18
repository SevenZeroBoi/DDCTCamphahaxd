using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    enum CharacterState
    {
        WAITING, COMPLETE, WRONGITEM, TIMEOUT
    }

    void PlayingWaiting()
    {
        //time deltatime -> if complete -> complete
        //if correct -> send out
    }

    void WrongItem()
    {

    }
}
