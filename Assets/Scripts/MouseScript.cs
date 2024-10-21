using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public static MouseScript instance;
    private void Awake()
    {
        instance = this;
    }

    public string currentMousePosition = "NONE";
    public GameObject boxcheck;

    public GameObject holdingItem = null;

    void Start()
    {
        /*
        itemOnSelf = new GameObject[CombinationSystem.instance.mainIngredients.Length];
        itemOnSelf = CombinationSystem.instance.mainIngredients.Concat(CombinationSystem.instance.elementIngredients).ToArray();*/
    }

    private void Update()
    {
        CursorHitbox();
        //FollowingText();

        if (Input.GetMouseButtonDown(0) && !GameStates.instance.isMouseOnHolding)
        {
            GameStates.instance.isMouseOnHolding = true;
            CheckShelfTag();
        }
        if (Input.GetMouseButtonUp(0) && GameStates.instance.isMouseOnHolding)
        {
            GameStates.instance.isMouseOnHolding = false;
            if (holdingItem != null)
            {
                holdingItem.GetComponent<ItemScript>().MovementChange();
                holdingItem.GetComponent<BoxCollider2D>().enabled = false;
                holdingItem.GetComponent<BoxCollider2D>().enabled = true;
            }
            holdingItem = null;
        }

        /*
        if (holdingItem != null)
        {
            holdingItem.transform.position = boxcheck.transform.position;
        }
        */
/*
        if (Input.GetMouseButtonDown(0) && OvenScript.instance.CanAddClickCounting && !GameStates.instance.isMouseOnHolding)
        {
            OvenScript.instance.currentClickTimes++;
        }*/


    }

    /*
    void FollowingText()
    {
        if (currentMousePosition != "NONE")
        {
            textcursor.text = currentMousePosition;
        }
        else
        {
            textcursor.text = "";
            textcursorpos.transform.position = boxcheck.transform.position;
            textcursorpos.transform.rotation = boxcheck.transform.rotation;
            textcursorpos.transform.localScale = boxcheck.transform.localScale;
        }
    }*/

    void CursorHitbox()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 campos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, Camera.main.nearClipPlane));
        boxcheck.transform.position = campos;
    }


    void CheckShelfTag()
    {
        for (int i = 0; i < ItemStorage.instance.shelfList.Length ; i++)
        {
            if (currentMousePosition == "NONE") break;
            else if (ItemStorage.instance.shelfList[i].tag == currentMousePosition)
            {
                holdingItem = ObjectPooling.instance.GetFromPool(ItemStorage.instance.itemOnShelf[i].name, ItemStorage.instance.itemOnShelf[i]
                    , boxcheck.transform.position, Quaternion.identity);
                break;
            }
            
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OVEN")
        {
            OvenScript.instance.CanAddClickCounting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "OVEN")
        {
            OvenScript.instance.CanAddClickCounting = false;
        }
    }

}

