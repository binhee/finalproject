using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : CombinationItem
{
    public GameObject[] result;

    public GameObject combinationResult;
    public GameObject Combine(GameObject ingredient)
    {
        if (ingredient.GetComponent<IngredientItem>().ingredientNum == 0)
        {
            combinationResult = result[0];
        }
        else if(ingredient.GetComponent<IngredientItem>().ingredientNum == 1)
        {
            combinationResult = result[1];
        }
        else if (ingredient.GetComponent<IngredientItem>().ingredientNum == 2)
        {
            combinationResult = result[2];
        }
        else if (ingredient.GetComponent<IngredientItem>().ingredientNum == 3)
        {
            combinationResult = result[3];
        }
        return combinationResult;
    }
}
