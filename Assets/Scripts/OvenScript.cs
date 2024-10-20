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
            
            OvenTriggering();
            //click to trigger the oven -> isTheOvenStart = true -> time.deltatime
        }
    }

    float cooldownCheck = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ITEMS" && !GameStates.instance.isOvenStarting && !other.gameObject.GetComponent<ItemScript>().isStillHolding)
        {
            GameStates.instance.currentItemCode.Add(other.gameObject.name);
            GameStates.instance.isOvenStarting = false;
        }

        
    }


    public int currentClickTimes = 0;
    int neededClickTimes = 10;
    bool isTheRecipeCorrect;
    public bool CanAddClickCounting = false;
    public void OvenTriggering()
    {
        if (currentClickTimes >= neededClickTimes)
        {
            currentClickTimes = 0;
            //change to ovenning
            CanAddClickCounting = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !GameStates.instance.isMouseOnHolding)
            {
                currentClickTimes++;
            }
        }

        if (CanAddClickCounting)
        {
            GameStates.instance.isOvenStarting = true;
        }



    }




    bool canAddMoreItem = false;
    int currentItemInOvenCounts;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ITEMS" && !GameStates.instance.isOvenStarting)
        {
            if (Input.GetMouseButtonUp(0) && canAddMoreItem)
            {
                GameStates.instance.currentItemCode.Add(collision.gameObject.name);
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
