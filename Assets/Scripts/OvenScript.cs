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
        if (GameStates.instance.isOvenStarting)
        {
            newObject = ItemStorage.instance.CheckCombineItem();
            GameStates.instance.isOvenStarting = false;
        }
        else
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
            anim.SetTrigger("oven");
            //change to ovenningae;
            currentClickTimes = 0;

        }
        else
        {
            if (Input.GetMouseButtonDown(0) && !GameStates.instance.isMouseOnHolding && !GameStates.instance.isOvenStarting && maxOvenitem == 2)
            {
                currentClickTimes++;
            }

        }

        if (!CanAddClickCounting)
        {
            GameStates.instance.isOvenStarting = true;
        }

        if (GameStates.instance.isOvenStarting)
        {
            currentcooldown += Time.deltaTime;
            if (currentcooldown >= cooldowncheck)
            {
                GameStates.instance.isOvenStarting = false;
                Instantiate(newObject, ovenCenter.transform.position, Quaternion.identity);
                anim.SetTrigger("idle");
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime == 1)
            {

            }
        }


    }

    int maxOvenitem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ITEMS" && !other.gameObject.GetComponent<ItemScript>().isStillHolding && !GameStates.instance.isOvenStarting && maxOvenitem < 2)
        {
            GameStates.instance.currentItemCode.Add(other.gameObject.name);
            maxOvenitem++;
        }


    }



}
