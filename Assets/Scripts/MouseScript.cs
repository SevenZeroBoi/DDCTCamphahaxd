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

    private bool isItemOnHold = false;

    public TMP_Text textcursor;
    public TextMeshProUGUI textcursorpos;

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

        if (Input.GetMouseButtonDown(0) && !isItemOnHold)
        {
            isItemOnHold=true;
            CheckShelfTag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isItemOnHold=false;
            if (holdingItem != null) holdingItem.GetComponent<ItemScript>().MovementChange();
            holdingItem = null;
        }

        /*
        if (holdingItem != null)
        {
            holdingItem.transform.position = boxcheck.transform.position;
        }
        */

        if (Input.GetMouseButtonDown(0) && CanAddClickCounting)
        {
            OvenScript.instance.currentClickTimes++;
        }
    }

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
    }

    void CursorHitbox()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 campos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, Camera.main.nearClipPlane));
        boxcheck.transform.position = campos;
    }

    void CheckShelfTag()
    {
        for (int i = 0; i < ItemStorage.Instance.shelfList.Length ; i++)
        {
            if (currentMousePosition == "NONE") break;
            else if (ItemStorage.Instance.shelfList[i].tag == currentMousePosition)
            {
                holdingItem = ObjectPooling.Instance.GetFromPool(ItemStorage.Instance.itemOnShelf[i].name, ItemStorage.Instance.itemOnShelf[i]
                    , boxcheck.transform.position, Quaternion.identity);
                break;
            }
            
        }
    }

    bool CanAddClickCounting = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OVEN")
        {
            CanAddClickCounting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "OVEN")
        {
            CanAddClickCounting = false;
        }
    }

}

