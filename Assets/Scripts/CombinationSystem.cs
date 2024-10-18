using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombinationSystem : MonoBehaviour
{
    public static CombinationSystem instance;


    private Dictionary<GameObject, string[]> combindingItems = new Dictionary<GameObject, string[]> ();
    [HideInInspector] public List<string> currentItemCode = new List<string>();

    public GameObject[] mainIngredients;
    public GameObject[] elementIngredients;
    public GameObject[] allResults;


    private void Awake()
    {
        instance = this;
    }

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


   
    public void CheckCombineItem()
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

    


}
