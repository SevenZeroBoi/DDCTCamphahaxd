using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OvenScript : MonoBehaviour
{

    public static OvenScript instance;
    private void Awake()
    {
        instance = this;
    }

    bool isTheOvenStart = false;
    bool canAddMoreItem = false;

    private void Update()
    {
        if (isTheOvenStart)
        {
            CombinationSystem.instance.CheckCombineItem();
            isTheOvenStart = false;
        }
        else
        {
            //click to trigger the oven -> isTheOvenStart = true -> time.deltatime
        }
    }

    float cooldownCheck = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ITEMS" && !isTheOvenStart && !other.gameObject.GetComponent<ItemScript>().isStillHolding)
        {
            CombinationSystem.instance.currentItemCode.Add(other.gameObject.name);
            other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, Time.deltaTime * 10);
            canAddMoreItem = false;
        }

        
    }


    public int currentClickTimes = 0;
    int needClickTimes;
    public void OvenTriggering()
    {
        //play animation
        currentClickTimes++;
        if (currentClickTimes >= needClickTimes)
        {
            currentClickTimes = 0;
            //change to ovenning
        }
    }

    public string[] wordList;
    public string pickedWord;
    public string currentWord;
    void WhileOvening()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ITEMS" && !isTheOvenStart)
        {
            if (Input.GetMouseButtonUp(0) && canAddMoreItem)
            {
                CombinationSystem.instance.currentItemCode.Add(collision.gameObject.name);
                collision.gameObject.transform.position = Vector3.MoveTowards(collision.transform.position, transform.position, Time.deltaTime * 10);
                canAddMoreItem =false;
            }
        }

        if (!canAddMoreItem && !isTheOvenStart)
        {
            cooldownCheck += Time.deltaTime;
            if (cooldownCheck > 1)
            {
                canAddMoreItem = true;
                cooldownCheck = 0;
            }
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        canAddMoreItem = true;
        cooldownCheck = 0;
    }*/

}
