using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static GameStates instance { get; private set; }

    [Header("Main States List")]
    public bool isCharacterOrder;
    public bool isMouseOnHolding;
    public bool isOvenStarting;

    [Header("Score System")]
    public int scoreCounts;
    public int scoreNeeded;
    public int dayCount;

    [Header("Current Order")]
    public int A;
}
