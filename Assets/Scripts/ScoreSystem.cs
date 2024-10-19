using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    public int currentGameScore;
    public int scoreperday;

    public float currentGameTime;
    public int currentGameDay;
    

    

    void CheckScorePerDay()
    {
        if (currentGameScore < scoreperday)
        {
            //game lose
        }
        else
        {
            CheckDayPass();
        }
    }

    void CheckDayPass()
    {
        // adding new quota // time speed up for npcs
    }


    void CheckCurrentGameTime()
    {
        currentGameTime += Time.deltaTime;
    }
    public void AddingScore (int fullscore, int correctpercentage)
    {
        currentGameScore += fullscore * (correctpercentage / 100);
    }

    public TMP_Text ScoreText;
    public TMP_Text ScoreRequired;
    public TMP_Text DayText;
    void UIUpdate()
    {
        ScoreText.text = currentGameScore.ToString("D5");
        DayText.text = currentGameDay.ToString();
        ScoreRequired.text = Convert.ToString(scoreperday);
    }

    

    
}
