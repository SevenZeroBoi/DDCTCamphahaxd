using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public int currentScore;
    public int neededScore;



    //Day Starting
    void GameDayStart()
    {
        //play day1 animation show
    }

    void GameDayUpdate()
    {

    }
}
