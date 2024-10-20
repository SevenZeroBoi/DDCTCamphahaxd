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

    public GameObject[] shelfList;
    public GameObject[] shelfLocationCheck;
    public GameObject[] itemOnShelf;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomizeJarLocation();
        }
    }

    public void RandomizeJarLocation()
    {
        System.Random randomvar = new System.Random();
        int n = shelfList.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = randomvar.Next(0, i + 1);
            GameObject temp = shelfList[i];
            shelfList[i] = shelfList[j];
            shelfList[j] = temp;
        }

        for (int i = 0; i < shelfList.Length; i++)
        {
            shelfList[i].transform.position = shelfLocationCheck[i].transform.position;
        }

    }

}
