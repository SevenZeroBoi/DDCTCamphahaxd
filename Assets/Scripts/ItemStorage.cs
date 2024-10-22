using System;
using System.Collections.Generic;
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
    public GameObject[] trash;

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
            combindingItems.Add(allResults[i], new string[] { mainIngredients[4].name, mainIngredients[i].name });
            /**/
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
                return trash[UnityEngine.Random.Range(0, trash.Length)];
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
