using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<string> stackToCheck;
   
    private ObjectType objectType;



    // return the index of the finding receipe
    public int Spwan(Transform cardBeStacked)
    {
       
        int stackToCheckLen = 0;
        stackToCheck = new List<string>();

        int satisfiedRecipeLength = 0; 
        int satisfiedRecipeLengthMax = satisfiedRecipeLength;
        int recipeIndex = -1;
        bool recipeSatisfied = false;
        


        for (int i = 0; i < Recipe.maxRecipeLength; i++)
        {
            objectType = cardBeStacked.gameObject.GetComponent<SaveableObject>().GetObjectType();
            stackToCheck.Add(objectType.ToString());
            stackToCheckLen++;
            if (cardBeStacked.transform.parent == null) break;
            else
            {
                cardBeStacked = cardBeStacked.transform.parent;
            }
        }



       
        for (int i = 0; i < Recipe.recipes.Count; i++)
        {
           // Debug.Log("recipe " + i);

            satisfiedRecipeLength = 0;
            recipeSatisfied = false;

            //j th card in the recipe
            for (int j = 1; j <= stackToCheckLen; j++)
            {
                if (Recipe.recipes[i].Count >= j && stackToCheck[j-1] == Recipe.recipes[i][j-1])
                {
                    satisfiedRecipeLength++;
                    if (j == (Recipe.recipes[i].Count)) recipeSatisfied = true;

                }
                else break;
            }



            if(recipeSatisfied && satisfiedRecipeLength > satisfiedRecipeLengthMax)
            {
                recipeIndex = i;
                satisfiedRecipeLengthMax = satisfiedRecipeLength;
            }
        }

        if(recipeIndex != -1)
        {
            return recipeIndex;
        }

        return -1;
    }
}
