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

    public int currentClickTimes = 0;
    int neededClickTimes = 10;
    bool isTheRecipeCorrect;
    public bool CanAddClickCounting = false;
    bool canAddMoreItem = false;
    float cooldownCheck = 0;


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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ITEMS" && canAddMoreItem && !other.gameObject.GetComponent<ItemScript>().isStillHolding && !GameStates.instance.isOvenStarting)
        {
            GameStates.instance.currentItemCode.Add(other.gameObject.name);
        }


    }



}
