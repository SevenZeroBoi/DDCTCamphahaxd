
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour

    
{

    public GameObject textKrub;
    public GameObject bgKrub;
    public static ScoreSystem instance;
    public TMP_Text text;
    private void Awake()
    {
        instance = this;
    }

    public GameObject dayText;
    public GameObject dayBackground;

    public TMP_Text timecheck;
    bool um = false;
    private void Update()
    {
        PreDayStart();

        if (GameStates.instance.currentCustomer != null)
        {
            if (GameStates.instance.currentCustomer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("npcend"))
            {
                ObjectPooling.instance.ReturnToPool(GameStates.instance.currentCustomer.name, GameStates.instance.currentCustomer);
                GameStates.instance.currentCustomer = null;
                
            }
        }

        text.text = "Score: " + GameStates.instance.scoreCounts.ToString();

        
        if (GameStates.instance.currentTimeCount <= 0 && um)
        {
            textKrub.SetActive(true);
            bgKrub.SetActive(true);
        }

    }
    void PreDayStart()
    {
        //play animation
        if (dayText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dayshowing"))
        {
            GameStates.instance.currentTimeCount = 90;
            um = true;
        }
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

        if (GameStates.instance.currentTimeCount <= 0)
        {
            GameStates.instance.isStoreisClosed = true;
        }
        else
        {
            timecheck.text = "Time Left: " + Mathf.Floor(GameStates.instance.currentTimeCount).ToString();
            GameStates.instance.currentTimeCount -= Time.deltaTime;
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