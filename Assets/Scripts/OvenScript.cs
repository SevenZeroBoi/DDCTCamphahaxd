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


    private void Update()
    {
        if (GameStates.instance.isOvenStarting)
        {
            ItemStorage.instance.CheckCombineItem();
            GameStates.instance.isOvenStarting = false;
        }
        else
        {
            //click to trigger the oven -> isTheOvenStart = true -> time.deltatime
        }
    }

    float cooldownCheck = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ITEMS" && !GameStates.instance.isOvenStarting && !other.gameObject.GetComponent<ItemScript>().isStillHolding)
        {
            ItemStorage.instance.currentItemCode.Add(other.gameObject.name);
            other.gameObject.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, Time.deltaTime * 10);
            GameStates.instance.isOvenStarting = false;
        }

        
    }


    public int currentClickTimes = 0;
    int needClickTimes;
    bool isTheRecipeCorrect;
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




    bool canAddMoreItem = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ITEMS" && !GameStates.instance.isOvenStarting)
        {
            if (Input.GetMouseButtonUp(0) && canAddMoreItem)
            {
                ItemStorage.instance.currentItemCode.Add(collision.gameObject.name);
                collision.gameObject.transform.position = Vector3.MoveTowards(collision.transform.position, transform.position, Time.deltaTime * 10);
                canAddMoreItem =false;
            }
        }

        if (!canAddMoreItem && !GameStates.instance.isOvenStarting)
        {
            cooldownCheck += Time.deltaTime;
            if (cooldownCheck > 1)
            {
                canAddMoreItem = true;
                cooldownCheck = 0;
            }
        }
    }


}
