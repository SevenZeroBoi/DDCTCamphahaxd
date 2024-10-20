using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;


    void DayStart()
    {
        GameStates.instance.currentTimeCount += Time.deltaTime;
        if (GameStates.instance.currentCustomer == null)
        {
            SummonNPCs(UnityEngine.Random.Range(0, 4));
        }
        else
        {

        }
    }

    public GameObject[] npcs;
    void SummonNPCs(int npcnumber)
    {
        GameStates.instance.currentCustomer = ObjectPooling.instance.GetFromPool(npcs[npcnumber].name, npcs[npcnumber], Vector3.zero, Quaternion.identity);
    }


}
