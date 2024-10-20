using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public static GameStates instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }

    [Header("Main States List")]
    public bool isCharacterOrder;
    public bool isMouseOnHolding;
    public bool isOvenStarting;

    [Header("Score System")]
    public int scoreCounts;
    public int scoreNeeded;
    public float currentTimeCount;
    public int dayCount;

    [Header("Current Order")]
    public GameObject currentCustomer;
    public GameObject currentNeededItem;
    public List<string> currentItemCode;
}
