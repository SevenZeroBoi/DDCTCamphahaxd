using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        isStillHolding = true;
    }

    [HideInInspector] public bool isStillHolding = true;
    public void MovementChange()
    {
        rb.gravityScale = 4;
        isStillHolding = false;
    }

    bool canMoveToTheOven = false;
    private void Update()
    {
        if (isStillHolding)
        {
            //transform.position = Vector3.MoveTowards(transform.position, MouseScript.instance.boxcheck.transform.position, Time.deltaTime * 5);
            transform.position = MouseScript.instance.boxcheck.transform.position;
        }
        else if (canMoveToTheOven)
        {
            transform.position = Vector3.MoveTowards(transform.position, OvenScript.instance.gameObject.transform.position, Time.deltaTime * 9);
            if (transform.position == OvenScript.instance.gameObject.transform.position)
            {
                rb.isKinematic = false;
                isStillHolding = true;
                canMoveToTheOven = false;
                ObjectPooling.instance.ReturnToPool(gameObject.name, gameObject);
            }
            //go to the oven
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            rb.gravityScale = 0;
            isStillHolding = true;
            canMoveToTheOven = false;
            ObjectPooling.instance.ReturnToPool(gameObject.name, gameObject);
        }

        if (collision.gameObject.tag == "OVEN" && !isStillHolding)
        {
            rb.isKinematic = true;
            canMoveToTheOven = true;
        }
    }
}
