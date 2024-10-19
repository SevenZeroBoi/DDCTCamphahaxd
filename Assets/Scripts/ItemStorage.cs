using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    public static ItemStorage Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject[] selfList;
    public GameObject[] selfLocationCheck;
    public GameObject[] itemOnSelf;


    public void RandomizeJarLocation()
    {
        System.Random randomvar = new System.Random();
        int n = selfList.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = randomvar.Next(0, i + 1);
            GameObject temp = selfList[i];
            selfList[i] = selfList[j];
            selfList[j] = temp;
        }

        for (int i = 0; i < selfList.Length; i++)
        {
            selfList[i].transform.position = selfLocationCheck[i].transform.position;
        }

    }

}
