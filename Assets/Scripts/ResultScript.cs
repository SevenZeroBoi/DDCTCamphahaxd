using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            ObjectPooling.instance.ReturnToPool(gameObject.name, gameObject);
        }
    }
}