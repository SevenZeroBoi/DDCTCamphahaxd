using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombinationSystem : MonoBehaviour
{
    public static CombinationSystem instance;


    private Dictionary<GameObject, string[]> combindingItems = new Dictionary<GameObject, string[]> ();
    private List<string> currentItemCode = new List<string>();

    public GameObject[] mainIngredients;
    public GameObject[] elementIngredients;
    public GameObject[] allResults;
    

    void SetUpRecipes()
    {
        for (int i = 0; i < mainIngredients.Length;i++)
        {
            combindingItems.Add(allResults[i], new string[] { mainIngredients[0].name ,mainIngredients[i].name });
            combindingItems.Add(allResults[i+5], new string[] { mainIngredients[0].name, mainIngredients[i].name, elementIngredients[0].name });
            combindingItems.Add(allResults[i + 10], new string[] { mainIngredients[0].name, mainIngredients[i].name, elementIngredients[1].name });
            combindingItems.Add(allResults[i + 15], new string[] { mainIngredients[0].name, mainIngredients[i].name, elementIngredients[2].name });
        }
    }


    bool isTheOvenStart = false;
    bool canAddMoreItem = false;
    void CheckCombineItem()
    {
        foreach (var num in combindingItems)
        {
            if (currentItemCode.ToArray() == num.Value)
            {
                //New item get lolx dd
                currentItemCode = null;
                break;
                
            }
        }
    }

    private void Update()
    {
        if (isTheOvenStart)
        {
            CheckCombineItem();
            isTheOvenStart = false;
        }
        else
        {
            //click to trigger the oven -> isTheOvenStart = true -> time.deltatime
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Items" && canAddMoreItem && Input.GetMouseButtonUp(0))
        {
            currentItemCode.Add(collision.gameObject.name);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
