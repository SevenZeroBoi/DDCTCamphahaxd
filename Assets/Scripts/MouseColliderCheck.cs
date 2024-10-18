using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseColliderCheck : MonoBehaviour
{
    [SerializeField] private int colliderCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        MouseScript.instance.currentMousePosition = other.gameObject.tag;
        colliderCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliderCount--;
        if (colliderCount == 0)
        {
            MouseScript.instance.currentMousePosition = "NONE";
        }
    }


}
