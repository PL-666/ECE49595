using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private List<string> stackToCheck;
    private Vector3 genCardOffset = new Vector3(-2,Drag.selectHeight,0);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Spwan(Transform cardBeStacked)
    {
        int stackToCheckLen = 0;
        stackToCheck = new List<string>();

        int satisfiedRecipeLength = 0; 
        int satisfiedRecipeLengthMax = satisfiedRecipeLength;
        int recipeIndex = -1;
        bool recipeSatisfied = false;
        GameObject genObject;


        //maxRecipeLength = 4
        //have 4 cards in the array.
        //0,1,2,3
        for (int i = 0; i < Recipe.maxRecipeLength; i++)
        {
            stackToCheck.Add(cardBeStacked.name);
            stackToCheckLen++;
            if (cardBeStacked.transform.parent == null) break;
            else
            {
                cardBeStacked = cardBeStacked.transform.parent;
            }
        }

  

        for (int i = 0; i < stackToCheckLen; i++)
        {
           // Debug.Log(stackToCheck[i]);
        }



       
        for (int i = 0; i < Recipe.recipes.Count; i++)
        {
           // Debug.Log("recipe " + i);

            satisfiedRecipeLength = 0;
            recipeSatisfied = false;

            //j th card in the recipe
            for (int j = 1; j <= stackToCheckLen; j++)
            {
                // Debug.Log("recipe " + i + " " + j);
                //stop when the recipe size is samller than the stackToCheckLen
                if (Recipe.recipes.Count >= j && stackToCheck[j-1] == Recipe.recipes[i][j-1])
                {
                    // Debug.Log(stackToCheck[j-1]);
                    //Debug.Log("recipe " + i + " " + j-1 + " s ");
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
            genObject = Instantiate(Recipe.recipesTarget[recipeIndex],
                cardBeStacked.transform.position + genCardOffset
                ,Recipe.recipesTarget[recipeIndex].transform.rotation);
            genObject.name = Recipe.recipesTarget[recipeIndex].name;
            genObject.GetComponent<Drag>().generate = true;
                gameObject.GetComponent<SoundUtility>().playSpawnCardSound();
          //  Debug.Log(Recipe.recipesTarget[recipeIndex]);
        }
    }
}
