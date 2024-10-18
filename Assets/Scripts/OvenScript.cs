using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenScript : MonoBehaviour
{
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Items" && !isTheOvenStart)
        {
            if (Input.GetMouseButtonUp(0) && canAddMoreItem)
            {
                CombinationSystem.instance.currentItemCode.Add(collision.gameObject.name);
                canAddMoreItem=false;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        canAddMoreItem = true;
        cooldownCheck = 0;
    }
}
