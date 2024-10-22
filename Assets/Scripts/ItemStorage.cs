using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class ItemStorage : MonoBehaviour
{
    public static ItemStorage instance;

    private void Awake()
    {
        instance = this;

        SetUpShelfLocation();
        SetUpRecipes();
    }

    public GameObject[] shelfList;
    public GameObject[] shelfLocationCheck;
    public GameObject[] itemOnShelf;
    public GameObject[] mainIngredients;
    //public GameObject[] elementIngredients;
    public GameObject[] allResults;

    public Dictionary<GameObject, string[]> combindingItems = new Dictionary<GameObject, string[]>();
    void SetUpShelfLocation()
    {
       
        for (int i = 0; i < shelfList.Length; i++)
        {
            shelfList[i].transform.position = shelfLocationCheck[i].transform.position;
        }
    }
    void SetUpRecipes()
    {
        mainIngredients = itemOnShelf;
        for (int i = 0; i < mainIngredients.Length; i++)
        {
            combindingItems.Add(allResults[i], new string[] { mainIngredients[0].name, mainIngredients[i].name });
            combindingItems.Add(allResults[i + 5], new string[] { mainIngredients[0].name, mainIngredients[i].name, "WATER" });
            combindingItems.Add(allResults[i + 10], new string[] { mainIngredients[0].name, mainIngredients[i].name, "FIRE" });
            combindingItems.Add(allResults[i + 15], new string[] { mainIngredients[0].name, mainIngredients[i].name, "GROUND" });
        }
    }

    public GameObject CheckCombineItem()
    {
        foreach (var item in combindingItems)
        {
            if (item.Value.SequenceEqual(GameStates.instance.currentItemCode))
            {
                return item.Key;
            }
            else
            {
                return allResults[UnityEngine.Random.Range(0, allResults.Length)];
            }
        }
        return allResults[UnityEngine.Random.Range(0, allResults.Length)];;
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
