using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject dayText;
    public GameObject dayBackground;

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
        
        if (GameStates.instance.currentCustomer == null && !GameStates.instance.isStoreisClosed)
        {
            SummonNPCs(UnityEngine.Random.Range(0, npcsList.Length));
        }

        if (GameStates.instance.currentTimeCount >= 60)
        {
            GameStates.instance.isStoreisClosed = true;
        }
        else
        {
            GameStates.instance.currentTimeCount += Time.deltaTime;
        }
    }
    void ContinueDialogue()
    {
        DialogueManager.instance.ContinueStory();
    }

    public GameObject[] npcsList;
    void SummonNPCs(int npcnumber)
    {
        GameStates.instance.currentCustomer = ObjectPooling.instance.GetFromPool(npcsList[npcnumber].name, npcsList[npcnumber], Vector3.zero, Quaternion.identity);
    }

}