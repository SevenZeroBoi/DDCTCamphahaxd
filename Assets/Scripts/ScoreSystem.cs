using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject dayText;

    private void Update()
    {
        PreDayStart();
    }
    void PreDayStart()
    {
        //play animation
        if (dayText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dayidle"))
        {
            DayStart();
        }


    }
    void DayStart()
    {
        GameStates.instance.currentTimeCount += Time.deltaTime;
        if (GameStates.instance.currentCustomer == null)
        {
            SummonNPCs(UnityEngine.Random.Range(0, npcs.Length));
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
