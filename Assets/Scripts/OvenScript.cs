using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class OvenScript : MonoBehaviour
{

    public static OvenScript instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject ovenCenter;
    

    public int currentClickTimes = 0;
    int neededClickTimes = 10;
    public bool CanAddClickCounting = false;

    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    GameObject newObject;
    private void Update()
    {

        {
            OvenTriggering();
            //click to trigger the oven -> isTheOvenStart = true -> time.deltatime
        }
    }


    float cooldowncheck = 4;
    float currentcooldown = 0;
    public void OvenTriggering()
    {
        if (currentClickTimes >= neededClickTimes)
        {
            newObject = ItemStorage.instance.CheckCombineItem();
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetTrigger("oven");
            GameStates.instance.isOvenStarting = true;
            //change to ovenningae;
            currentClickTimes = 0;
            maxOvenitem = 0;

        }
       
        {
            if (Input.GetMouseButtonDown(0) && !GameStates.instance.isMouseOnHolding && !GameStates.instance.isOvenStarting && maxOvenitem == 2 && CanAddClickCounting)
            {
                currentClickTimes++;
                anim.SetTrigger("shake");
            }

        }

        if (GameStates.instance.isOvenStarting)
        {
            currentcooldown += Time.deltaTime;
            if (currentcooldown >= cooldowncheck)
            {
                Instantiate(newObject, ovenCenter.transform.position, Quaternion.identity);
                anim.SetTrigger("idle");
                GetComponent<BoxCollider2D>().enabled = true;
                currentcooldown = 0;
                GameStates.instance.isOvenStarting = false;

            }
        }


    }

    public int maxOvenitem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ITEMS" && !other.gameObject.GetComponent<ItemScript>().isStillHolding && !GameStates.instance.isOvenStarting && maxOvenitem < 2
            && GameStates.instance.isCharacterOrder)
        {
            GameStates.instance.currentItemCode.Add(other.gameObject.name);
            maxOvenitem++;
            anim.SetTrigger("shake");
        }


    }



}
